using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [HideInInspector] public bool isGameOn;
    [HideInInspector] public static GameState sharedInstance;

    private void Start()
    {
        sharedInstance = this;
    }
}
