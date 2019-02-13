# Generic GameOobject Pooler

This is a generic gameobject pooler that allows you to manipulate a group of prefabs or gameobjects as keys of dictionaries.

The main purpose of this class is to manage how many instances of an object you have already instantiated, that way 

avoiding possible memory leaks and consequently glinches during the game because of a smash of the garbage collector.
