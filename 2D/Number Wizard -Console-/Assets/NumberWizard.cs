using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int min = 1;
    int max = 100;
    int guess = 50;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Debug.Log("Welcome to Number Wizard");
        Debug.Log("Pick a number between " + min + " and " + max);
        Debug.Log("Tell me if your number is higher or lower than " + guess);
        Debug.Log("Push UP = Higher, Push DOWN = Lower, Push ENTER = Correct");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow was Pressed");
            min = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow was Pressed");
            max = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Yay I Won!!!!! Whoop Whoop");
            StartGame();
        }

    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("Is it higher or lower than... " + guess);
    }
}
