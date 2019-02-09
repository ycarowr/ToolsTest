# Push/Pop Generic Finite State Machine in Unity using Monobehavior

This is an implementation of an abstract Push/Pop Generic Finite State Machine using the Monobehavior as a base class. 

Some restrictions:
- The concrete state machine and all the states (components) have to be attached to a single gameobject. Most likely a prefab.

Some benefits:
- The implementation demands the user/programmer to keep each State in a single separated file/monobehavior/component, in other words, it enforces the single responsability principle of each behavior/state.
- Flexibility of to make a lot schenanigans such as assign serializable variables to states use of coroutines and etc. I'd like to remind that all the unity callbacks also live in each state because everything is inside the "Monobehavior world", for simple games its amazing, however not all the games can "afford" it. 

If you really need this flexibility and want to keep each behavior in different classes go for this implementation. Otherwise, you can switch to another implementation that fits better in your game.


Example: 
This implementation is very useful to manage a turn based game, where you can create single states with their own specific behaviors and control the game flow:

1. Player Turn State: handle actions during the turn of generic player. Exemple: Timer of the turn;
2. User Turn State: handle actions of the User. Exemple: Enable Input;
2. Ai Turn State: handle actions of the AI. Example: contains the Ai module to calculate the best card to be played;
3. Pregame Setup State: handle all the pre game configurations. Exemple: decide which player goes first and drag starting hand;
4. Game Finished State: Win/Lose (both can be broken in two single separed states as well)



