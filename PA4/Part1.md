1. Why do modern programming languages not include the goto command? When is it justified?
   
 Modern programming languages avoid goto because it can cause 'spaghetti code' which hinders the readability, writability, and maintainability of the code. It breaks the structured programming principles by allowing arbitrary jumps in the control flow. Which makes debugging and reasoning about program behavior very difficult.

 Both articles acknowledge that goto is sometimes justified for cleanup in low level code and linux/kernel systems. In Linux Kernel Discussion it mentioned that goto is sometimes justified for when there is cleanup in low level code that causes multiple exit points that cause redundancy like error handling in C. Similarly in the XML book excerpt it says that goto is practical for early exits in nested blocks when performance or clarity in exception handling has higher priority. 

 Overall even if structured programming says not to use goto in higher level logic it is justified for resource deallocation and exiting deep nesting. 

2. Key design issues for counter-controlled loops + example (C++)

   Design Issues:
   - Type and scope of the loop control variable
   - Whether or not loop variables or parameters change within the body
   - Evaluation frequency of loop parameters
   - Post-loop value of the control variable

Example in C++;
for (int i = 0; i < 10; i++) {
    cout << i << endl;
}

3. Why C++ prefer pass-by-reference for large data, and what’s the drawback?

   C++ prefers pass by reference because it avoids copying large objects, and saves memory and execution time. Copying large objects can have a lot of overhead for the memory and is not very scalable for the performance. The function having a reference to the object makes the execution more efficient and faster.

   Some drawbacks of passing by reference is that aliasing can occur which means function modifies original data which leads to unwanted side effects. This can overall decrease readability and reliability, however it can be mitigated by using const references to avoid modification of the original object and improve clarity.

4. Define variadic arguments & Python implementation with examples

  Variadic arguments in python allow functions to accept any variable number of parameters.The terms used in python are :
      - *args = non-keyword arguments as a tuple
      - **kwargs = keyword arguments as a dictionary
EX:
def print_all(*args):
    for arg in args:
        print(arg)

def greet(**kwargs):
    print(f"Hello {kwargs['name']}")

EX:
def describe_pet(*traits, **details):
    print("Traits:")
    for trait in traits:
        print(f"- {trait}")

    print("\nDetails:")
    for key, value in details.items():
        print(f"{key}: {value}")
        
describe_pet("furry", "friendly", name="Buddy", species="Dog", age=5)

5. What are coroutines and why are they “quasi-concurrent”? Python example.

- Coroutines: Special subprograms that can pause (yield) and resume execution which retains state between the calls. They treat the caller and callee symmetrically, rather than the caller controlling the flow. Similar to a peer to peer architecture, one coroutine can give up control to another and resume later.
  - The "Quasi-concurrent" means that they allow interleaved execution without true parallelism. This is because the coroutines run one at a time.

EX: In python coroutines are implemented with at least one yield expression, then call the function to get the generator objects. After that you can prime the coroutine using next() before sending the values, then use send() to pass the data into the coroutine and close() to stop. 

def logger():
    print("Logger started")
    while True:
        message = yield
        print(f"LOG: {message}")

#Create coroutine
log = logger()

#Prime it
next(log)

#Send messages
log.send("User logged in")
log.send("User clicked button")

#Close coroutine
log.close()

6. Four pillars of OOP with HW 5 examples (C#)
   1. Abstraction: Hides the internal implementation details from the user and only shows essential features or behaviors of an object. For example in HW 5 I have an abstract class "Product" that provides a common interface for all product types. It defined abstract methods like GetProdTypeStr() and DisplayContentsInfo(), forcing derived classes to implement only what is relevant to their product, which hides the irrelevant complexity from the cart logic.
   2. Encapsulation: limits direct access to internal object data which enforces control through getters and setters. In HW 5 all my classes member variables like productName, price, reviewRate, singer, and author are private/protected. The access to them is controlled through public methods like SetPrice and GetProdName which keeps the internal state safe while making sure all updates pass through a controlled interface.
   3. Inheritance: Allows a class (child) to get fields and behaviors (methods) from another class (parent), which promotes code reusability and hierarchy. In HW 5 my hierarchy starts at product as the base class. AudioProduct, VideoProduct, and BookProduct inherit from Product class. Then to further it EBook and PaperBook inherit from BookProduct. This will make sure all product types share logic from the product, while only extending and overriding what is needed.
   4. Polymorphism: Allows methods to behave differently depending on the object that is calling them, even in a shared interface. Pretty much allows objects to be part of the same superclass. In HW 5 the method DisplayProdInfo() is defined in the Product Class and overridden in each subclass to have product specific details. In Cart.cs, I stored all product types as Product, but when I call DisplayProdInfo(), it shows me the correct subclass details for each product. 



