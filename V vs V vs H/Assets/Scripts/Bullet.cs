using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public CompositeCollider2D collision;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collision = FindObjectOfType<CompositeCollider2D>();
    }
    private void Update()
    {
        if(rb.IsTouching(collision))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player-2")
        {
            Debug.Log("Player-1 Wins");
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (collision.tag == "Player-1")
        {
            Debug.Log("Player-2 Wins");
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }


    }

}
