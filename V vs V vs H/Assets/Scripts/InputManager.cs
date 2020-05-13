using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;
public class InputManager : MonoBehaviour
{
    int playersJoined = 0;
    GM gm = null;

    private void Awake()
    {
        gm = FindObjectOfType<GM>();
    }

    void OnPlayerJoined()
    {
        playersJoined += 1;
    }


    private void LateUpdate()
    {
        if (playersJoined == 2)
        {
            gm.StartGame();
        }
    }
}
