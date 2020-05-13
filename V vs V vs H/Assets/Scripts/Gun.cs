using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Gun : MonoBehaviour
{
    private Player_Controls player;
    private SpriteRenderer sprite;
    public GameObject bullet;
    public Vector2 bulletStart;
    public float bulletSpeed = 10.0f;
    private BoxCollider2D box;
    private bool insideWall = false;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Controls>();
        sprite = this.GetComponent<SpriteRenderer>();
        bulletStart = new Vector2(1, 0.2f);
        box = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteUpdate();
    }

    void SpriteUpdate()
    {
        if (player.m_fHorizontalInput > 0)
        {
            sprite.flipX = false;
            bulletStart.x = 1;
            box.offset = new Vector2(0.5f, 0.2f);
        }
        else if (player.m_fHorizontalInput < 0)
        {
            sprite.flipX = true;
            bulletStart.x = -1;
            box.offset = new Vector2(-0.5f, 0.2f);
        }
        else { }
    }

    public void Fire()
    {
        if(!insideWall)
        {
            if(!bullet.activeSelf)
            {
                bullet.transform.position = (Vector2)this.transform.position + bulletStart;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletStart.x * bulletSpeed, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        insideWall = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insideWall = false;
    }
}
