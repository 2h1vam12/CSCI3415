# 🧮 CSCI 3421 – Homework 2: Tiny Calculator Using (f)lex

This assignment is a prerequisite for Homework 3 and introduces the fundamentals of **lexical analysis** using the Unix tool **(f)lex**. The goal is to build a **basic arithmetic expression calculator** and define regular expressions for foundational tokens used in programming languages.

>  **This assignment sets the groundwork for full syntax analysis with `bison/yacc` in Homework 3.**

---

##  Features

- Binary expression calculator supporting:
  - Addition (+), Subtraction (−), Multiplication (×), Division (÷), Exponentiation (^)
- Accepts both integers and floating-point numbers
- Handles valid input gracefully
- Detects and reports syntax/operand/operator errors

---

## ✏ Regular Expressions Defined

- Alphabet  
- Digit  
- Alphanumeric  
- Identifier  
- Unsigned Integer  
- Unsigned Decimal Number  
- Unsigned Scientific Notation  

> Defined in comments or attached Markdown file

---

##  Build & Run

```bash
$ lex tinyCalc.l       # or flex tinyCalc.l
$ gcc lex.yy.c -o tinyCalc -lm
$ ./tinyCalc
