/* calc.y - Tiny Calculator Grammar
-------------------------------------------------------
BNF grammar Rules
〈input〉: entire session input (can be empty or multiple lines)
〈line〉: a single line (can be an expression, assignment, variable lookup, or error)
〈stmt〉: a statement to evaluate or assign
〈expr〉: arithmetic expression
〈NUMBER〉: integers or floats
〈VAR〉: valid variable names (identifiers)
〈OPERATOR〉: +, -, *, /, ^, =

〈input〉 ::= ε
          | 〈input〉 〈line〉

〈line〉 ::= '\n'
         | 〈stmt〉 '\n'
         | error '\n'

〈stmt〉 ::= 〈expr〉
         | 〈VAR〉 '=' 〈expr〉
         | 〈VAR〉

〈expr〉 ::= 〈NUMBER〉
         | 〈VAR〉
         | 〈expr〉 '+' 〈expr〉
         | 〈expr〉 '-' 〈expr〉
         | 〈expr〉 '*' 〈expr〉
         | 〈expr〉 '/' 〈expr〉
         | 〈expr〉 '^' 〈expr〉
         | '(' 〈expr〉 ')'
         | '-' 〈expr〉  %prec UMINUS
         | '+' 〈expr〉  %prec UPLUS

〈NUMBER〉 ::= [0-9]+(\.[0-9]+)?

〈VAR〉 ::= [a-zA-Z_][a-zA-Z0-9_]*

------------------------------------------------------- */
%{
#include <iostream>
#include <map>
#include <cmath>
#include <cstdlib>
#include <cstring>
#include <signal.h>

extern int yylex();
extern int yyparse();
extern FILE *yyin;
void handle_sigint(int sig) {
    std::cout << "\nReceived Ctrl+C (SIGINT). Exiting cleanly...\n";
    exit(0);
}
void yyerror(const char *s);
int calc_count = 0;
std::map<std::string, double> vars;
%}

%union {
    double dval;
    char* var;
}

%token <var> VAR
%token <dval> NUMBER

%left '+' '-'
%left '*' '/'
%right '^'
%right '='
%right UPLUS UMINUS

%type <dval> expr stmt

%%
input:
      /* empty */
    | input line
    ;

line:
      '\n'
    | stmt '\n' {
        ++calc_count;
        if (!std::isnan($1)) {
            std::cout << "= " << $1 << std::endl;
        }
    }
    | error '\n' { yyerrok; }
    ;

stmt:
      expr { $$ = $1; }
    | VAR '=' expr {
        vars[$1] = $3;
        std::cout << "Variable " << $1 << " is assigned to " << $3 << std::endl;
        $$ = $3;
        free($1);
    }
    | VAR {
        std::string name($1);
        if (vars.find(name) == vars.end()) {
            std::cout << "Error: \"Variable, " << name << ", not found!\" at calculation: " << calc_count << std::endl;
            $$ = NAN;
        } else {
            $$ = vars[name];
        }
        free($1);
    }
    ;

expr:
      NUMBER { $$ = $1; }
    | VAR {
        std::string name($1);
        if (vars.find(name) == vars.end()) {
            std::cout << "Error: \"Variable, " << name << ", not found!\" at calculation: " << calc_count << std::endl;
            $$ = NAN;
        } else {
            $$ = vars[name];
        }
        free($1);
    }
    | expr '+' expr { $$ = $1 + $3; }
    | expr '-' expr { $$ = $1 - $3; }
    | expr '*' expr { $$ = $1 * $3; }
    | expr '/' expr {
        if ($3 == 0) {
            std::cout << "Error: \"divide by zero !!\" at calculation: " << calc_count << std::endl;
            $$ = NAN;
        } else {
            $$ = $1 / $3;
        }
    }
    | expr '^' expr { $$ = pow($1, $3); }
    | '(' expr ')' { $$ = $2; }
    | '-' expr %prec UMINUS { $$ = -$2; }
    | '+' expr %prec UPLUS { $$ = $2; }
    ;
%%

void yyerror(const char *s) {
    std::cout << "Error: \"" << s << "\" at calculation: " << calc_count << std::endl;
}

int main() {
    signal(SIGINT, handle_sigint);
    std::cout << "Enter Any Arithmetic expression." << std::endl;
    yyparse();
    return 0;
}