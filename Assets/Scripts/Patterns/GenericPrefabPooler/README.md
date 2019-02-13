# Generic Prefab/GameObject Pooler

This is a generic gameobject pooler that allows you to manipulate a group of prefabs or gameobjects as keys of dictionaries.
The main purpose of this class is to manage how many instances of an object you have already instantiated, that way 
avoiding glinches in the game because an Instantiate call.

Inside the scene named TestPrefabPool you can find a simple sample of the usage:
https://github.com/ycarowr/Tools/tree/master/Assets/Scenes

This is how looks like the Pooler inside the scene:

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/GenericPrefabPooler/Images/Capture.GIF)

This is how looks like the script that makes use of the pooler:

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/GenericPrefabPooler/Images/Capture1.GIF)

This is the pooler operating:

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/GenericPrefabPooler/Images/prefab.gif)

