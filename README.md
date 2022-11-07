# Sharptory
A simple C# library that consists of several abstract factories aimed at solving many use cases in C# solutions.

**List of factories:**
- **AbstractFactory** - Abstract factory used to create instances (of registered classes) that inherit from a specific parent.
- **AbstractFactoryWithParam** - Abstract factory used to create instances (with parameter) that inherit from a specific parent.
- **ConvertorToOneFactory** - Abstract factory that creates a converter (adapter) given a parameter to convert it to object of a specific class. The convertor is chosen by type of parameter.
- **ConvertorToManyFactory** - Abstract factory that creates a converter (adapter) with a given parameter of a specific class to convert it to object of the class selected by the key.
- **Mediator** - Mediator calls registered action by type of given parameter.
