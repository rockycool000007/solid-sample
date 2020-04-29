# Step 3 : Open/Closed Principle

## Use simple Inheritance with virtual members in this sample

# 1. Make public methods virtual
Make all the methods virtual that can be overriden by a child class.
This allows you to keep your classes open for extension and closed for modification.
Changes are made in the DealStorage, DealCaching, DealSerializer, DealLogger to make the methods virtual.
So, if you add a TestCaching class and want to change behaviour of a method, you can by just overriding the method.


# 2. Add some Factory Methods using virtual properties

