# Wrapping the Generic Collection and adding some funcionalities 

This is not an extension of the class System.Collections.Generic. 
I made this class because I found myself wrapping the generic List<T> class inside another class an many times. The reasons could be a new funcionality not implemented by the standard calss or to avoid the usage of Linq extensions. 
  
Basically, you have Add and Remove operations already checking and raising exceptions for adding null or duplicated elements and some auxiliar methods such as Shuffle or GetAndRemoveRandomElement(), these are very useful when you're making a game that manipulates a collection of elements like cards, tiles, enemies, characters, etc. 
  
Inside the Editor folder you can also find a test class used in my Unit Tests and some practice of Test Driven Development using the Collection<T> class:
  
![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/GenericCollection/Images/tdd%20collection.GIF)

