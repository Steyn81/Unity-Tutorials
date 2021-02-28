using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Needed for Text

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    //Will keep track of which state we are in
    State state;

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }

        textComponent.text = state.GetStateStory();
    }
}
//States and State Machines
//--------------------------------------------------------------------------------
//State = Action/Process/Behaviour (the thing that we are doing usually.)
//State Machine assumes only 1 state at a time.(but can have many states)
//Conditions (requirements) transition from one state to the next.

//Example of State Machine
//Start => State A => Decision? => (Decision 1) State B    / Start => Room with 2 Exits => Which Way? => (Blue Door) Real World
//                              => (Decision 2) State C     /                                          => (Red Door) Fantasy Land

//Scriptable Object
//--------------------------------------------------------------------------------
//ScriptableObject It's a class that lets us store data in stand alone assets
//Keep mountains of data out of our scripts
//It's lightweight and convenient
//Used as a template for consistency

//              Our Code                                    Scriptable Objects
//  ------------------------------                      ----------------------
//  |       AdventureGame.cs     |             ||=====  |    Story Data A    |
//  ------------------------------             ||       ----------------------
//  |  |Display Story Text: |    |             ||       ---------------------- 
//  ------------------------------             ||=====  |    Story Data B    |
//  |       |Story Data C |      |  <==========||       ---------------------- 
//  |       ---------------      |             ||       ---------------------- 
//  |                            |             ||=====  |    Story Data C    |
//  ------------------------------                      ---------------------- 

// Create a new Scriptable Object
//---------------------------------------------------------------------------------
// Add new script => open new script => change MonoBehaviour to ScriptableObject
