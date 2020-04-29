# Step 4 : Liskov Substitution Principle

#### Using dapper as micro ORM

- Try Create a new SQLDealStorage by inheriting from DealStorage
- See that GetFileName method have no sens in this class and that it's a violation of the LSP
- See that path is not really the path anymore and that it's a violation of the LSP

This is just to show how is LSP violated.
The reason is that a child class must be substitutable for a base class to use. In the SQLDealStorage child class, it cant be substituted since two of its methods are not implemented and throwing exception.
