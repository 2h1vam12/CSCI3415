# CSCI 3421 – Homework 3: Tiny Calculator with Syntax Analysis

This assignment extends Homework 2 by implementing **syntax analysis** using **bison/yacc**, completing the front-end compiler phase in conjunction with **lexical analysis using flex**.

> The full calculator now supports **expressions with variables, signed numbers, and proper operator precedence**, using flex for tokenizing and bison for grammar-based parsing.

---

##  Objectives

- Build a full syntax analyzer using **flex + bison/yacc**
- Understand the compiler frontend: **lexical + syntactic analysis**
- Implement a **tiny arithmetic calculator** with variable support and error handling
- Apply **BNF grammar rules** to structure expression evaluation
- Compare capabilities of flex vs. bison

---

##  Supported Features

- Integer and floating-point arithmetic
- Binary operations: `+`, `-`, `*`, `/`, `^`
- Expression grouping with parentheses
- Variable assignments and evaluation
- Signed values (e.g., `2 - -3`)
- Input error detection:
  - Invalid tokens
  - Mismatched parentheses
  - Division by zero
  - Undefined variables

---

## ⚙ Build & Run

$ flex calc.l
$ bison -dtv calc.y
$ mv lex.yy.c lex.yy.cpp
$ mv calc.tab.c calc.tab.cpp
$ g++ -std=c++11 -c lex.yy.cpp -lm
$ g++ -std=c++11 -c calc.tab.cpp -lm
$ g++ -o calc *.o -lstdc++ -lm
$ ./calc
