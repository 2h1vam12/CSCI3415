# CSCI 3415 Homework 4: Social Sentiment Score Analyzer in Rust
### Shivam Pathak

This assignment implements a sentiment analysis tool in Rust, a memory-safe systems language. The goal was to build a dictionary of sentiment word scores, apply them to a review file, and convert the overall sentiment to a star rating.

## Approach

- I read `socialsent.csv` using a buffered file reader, parsed each line into word-score pairs, and stored them in a `HashMap`.
- The review file is read line-by-line, and each word is cleaned (lowercased, punctuation removed) before being matched in the sentiment table.
- The program computes a cumulative sentiment score, then classifies it using a multi-way `match` block into 1–5 stars.
- Modular design: the project uses three core subprograms:
  - `build_social_sentiment_table(...)`
  - `get_social_sentiment_score(...)`
  - `get_star_rating(...)`


##  What I Learned About Rust

- How Rust enforces memory safety through ownership and borrowing instead of garbage collection.
- That you must think explicitly about who "owns" a value and when it goes out of scope.
- Learned `HashMap` syntax and string manipulation, file I/O, and CLI args with `std::env`. With the help of some generative AI tools.

##  Unique Features of Rust

- Rust's **ownership model** eliminates entire classes of runtime bugs (like memory leaks and dangling pointers).
- `Option<T>` replaces nulls, avoiding unsafe dereferencing.
- No `new` or `delete` — memory is automatically freed when out of scope.

##  Features I Liked

- Pattern matching via `match` is clean and expressive.
- Built-in safety — no segfaults or memory errors to worry about.
- `HashMap`, `BufReader`, and other stdlib features are very modern and powerful.

##  Features I Didn’t Like

- Error handling via `.expect()` is verbose.
- Lifetimes and borrow checker were hard at first to understand.
- Slightly verbose compared to languages like Python. Similar Syntax to C 

##  Use of Generative Tools

ChatGPT was used to:
- Clarify syntax
- Help break the project into modular parts
- Provide example outputs for testing
- Research Rust and generate bits and peices of code (Like the hashmap and file I/O)
- Helped to run the code using command line.
- Helped me awnser questions on setting up the codespace in Replit, and also provided instructions on how to do it locally.
- Helped me create some debugging prompts (They are commented out in my code) when I was debugging and constantly got 5 stars for everything.
- Provided me with Python comparisons to Rust code to help me further understand the differences.

All in  all, Chat GPT was very helpful similar to "24 hour office hours", where I could ask questions about how to create the sentiment table and syntax in Rust. Also provided amazing support, to get started on Replit, debugging, and 
researching for Question 1. 

##  Files Included

- `main.rs`: Source code implementing the program
- `socialsent.csv`: CSV file with words and their sentiment scores
- `review.txt`: Default review file (can be swapped out)
- `good.txt`, `bad.txt`: Additional test reviews
- `PathakHw4outputs.txt` and 'PathakHw4outputs.pdf': Outputs of main.rs 
- `PathakCSCI3415Hw4Part1.pdf`: Answers to Part 1 of Homework 4
- `README.md`: You’re reading it :)
- *No Makefile is needed* 

##  How to Run (on Replit or locally)

- I ran and tested the code entirely on REPLIT [Replit](https://replit.com).
- No Makefile was needed, since Rust uses Cargo to build and run code:
  ```bash
  cargo run -- good.txt
  ```
