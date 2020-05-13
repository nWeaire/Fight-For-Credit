using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isPlayer1 = false;
    GM gameManager = null;
    public GameObject bullet = null;

    private void Awake()
    {
        gameManager = FindObjectOfType<GM>();
        if(this.gameObject.tag == "Player-1")
        {
            isPlayer1 = true;
        }
        gameManager.AddPlayer(this.gameObject);
    }

}
