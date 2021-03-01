using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1) //GetType() is getting the type that it is on (ex. Music Player)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
