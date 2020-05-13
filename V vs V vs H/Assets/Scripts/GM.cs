using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GM : MonoBehaviour
{
    List<GameObject> players; 
    GameObject p1 = null;
    GameObject p2 = null;
    public List<Vector2> p1Starts;
    public List<Vector2> p2Starts;
    public GameObject startCamera = null;


    private void Awake()
    {
    }

    public void StartGame()
    {
        //startCamera.SetActive(false);
        p1.SetActive(false);
        p2.SetActive(false);
        p1.transform.position = p1Starts[0];
        p2.transform.position = p2Starts[0];
        p1.SetActive(true);
        p2.SetActive(true);

    }

    public void AddPlayer(GameObject player)
    {

        if (player.tag == "Player-1")
        {
            p1 = player;
        }
        else
        {
            p2 = player;
        }
        
    }
}
