# Generic Collection

First of all, this is not an extension of the class System.Collections.Generic. I made this class because I found myself wrapping the generic List<T> class inside another class an insane amount of times, could be I wanted new funcionalities that List doesn't have to avoid the use of Linq extensions. Basically, you have Add and Remove operations already checking and raising exceptions for adding null or duplicated elements with some auxiliar methods such as Shuffle or GetAndRemoveRandomElement(), these are very useful when you're making a game that manipulates a collection of elements like cards, tiles, enemies, characters, etc. 
  
Inside the Editor folder you can also find a test class used in my Unit Tests and some practice of Test Driven Development using this Collection<T> class:
![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/GenericCollection/Images/tdd%20collection.GIF)

