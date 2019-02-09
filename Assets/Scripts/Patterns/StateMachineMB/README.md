# Push/Pop Generic Finite State Machine in Unity using Monobehaviors

This is an implementation of an abstract Push/Pop Generic Finite State Machine using the Monobehavior as a base class. 

Some details:
- The concrete state machine and all the states (components) have to be attached to a single gameobject before the initialization. It's better to have all in a single prefab.
- The implementation demands the user/programmer to keep each State in a single separated file/monobehavior/component, in other words, it enforces the single responsability principle of each behaviors/states (see more in https://en.wikipedia.org/wiki/Single_responsibility_principle).
- Flexibility to make Editor schenanigans such as assign variables to states or use of coroutines. I'd like to remind that all the unity callbacks also live in each state because everything is inside the "Monobehavior world", for simple games its amazing, however not all the games can "afford" it; 
- All the core methods is documented with its own summary and you have also plenty of other comments adding explanations about the code;

If you really need this flexibility and want to keep each behavior in different classes go for this implementation. Otherwise, you can switch to another implementation that fits better in your game.

Example of usage: 

This implementation is very useful to manage a turn based game, where you can create single states with their own specific behaviors and control the game flow:

1. Player Turn State: handle actions during the turn of generic player. Exemple: Time out of the turn;
2. User Turn State: handle actions of the User. Exemple: Enable Input;
2. Ai Turn State: handle actions of the AI. Example: contains the Ai module to calculate the best card to be played in a CCG;
3. Pregame Setup State: handle all the pre game configurations. Exemple: decide which player goes first and draw starting hand;
4. Game Finished State: Win/Lose (both can be broken in two single separed states as well)

- You can find a sample scene here: https://github.com/ycarowr/Tools it's located in the following path: Assets/Scenes/TestStateMachineMB.unity
- The test scene contains a concrete class for the state machine, for the states and some tests ;
- The current version has some logs along the method. You might remove it.

This is how looks like the prefab of the test state machine:

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/StateMachineMB/fsmstart.GIF)

These are the logs after the state machine initialization:

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/StateMachineMB/fsmstart.GIF)

The picture below shows the logs after the push operation of the AiState

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/StateMachineMB/aistate.GIF)

The picture below shows the logs after some operations 

![alt text](https://github.com/ycarowr/Tools/blob/master/Assets/Scripts/Patterns/StateMachineMB/operations.GIF)

