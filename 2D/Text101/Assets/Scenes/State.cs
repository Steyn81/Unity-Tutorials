using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add new option to unity menu structure (R-Click in unity)
[CreateAssetMenu (menuName = "State")] 
public class State : ScriptableObject
{
    //[TextArea(min size of field in the inspector, amount of lines before scroll]
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}
