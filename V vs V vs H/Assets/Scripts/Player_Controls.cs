using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
public class Player_Controls : MonoBehaviour
{
    [HideInInspector]
    public float m_fHorizontalInput = 0;
    public Vector2 movement;
    Rigidbody2D rb = null;
    public float speed = 10.0f;
    public float jumpPower = 10.0f;
    public float gravity = 5.0f;

    private Gun gun;

    public LayerMask layermask;
    private Vector2 HorizontalDirection;
    private Vector2 VerticalDirection;
    private BoxCollider2D box;
    public int horizontalRayCount = 4;
    public int VerticalRayCount = 4;

    public int points = 0;
    public PlayerInput pi;
    private InputUser user;
    private InputDevice device;
    private void Awake()
    {
        gun = this.GetComponentInChildren<Gun>();
        rb = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
        HorizontalDirection = new Vector2(0, 0);
        box = this.GetComponent<BoxCollider2D>();
        pi = this.GetComponent<PlayerInput>();
        if(pi.playerIndex == 0)
        {
            this.gameObject.name = "Player-1";
            this.gameObject.tag = "Player-1";
            this.gameObject.AddComponent<Player>();
        }
        else
        {
            this.gameObject.name = "Player-2";
            this.gameObject.tag = "Player-2";
            this.gameObject.AddComponent<Player>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_fHorizontalInput != 0)
        {
            movement.x = m_fHorizontalInput * speed;
        }

        move(movement);
        movement.x = 0;
    }
    void move(Vector2 Movement)
    {
        if(CheckHorizontalCollision())
        {
            Movement.x = 0;
        }
        if(CheckVerticalCollision())
        {
            Movement.y = 0;
            movement.y = 0;
        }
       
        this.transform.Translate(Movement * Time.deltaTime);    
    }

    bool CheckHorizontalCollision()
    {
        float dist = (box.bounds.extents.y * 2) / horizontalRayCount;
        HorizontalDirection.x = m_fHorizontalInput;
        HorizontalDirection.y = 0;
        Vector2 rayStartPosition = new Vector2(0,0);
        for (int i = 0; i < horizontalRayCount + 1; i++)
        {
            rayStartPosition.x = this.transform.position.x;
            rayStartPosition.y = this.transform.position.y + (dist * i);            
            if (Physics2D.Raycast(rayStartPosition, HorizontalDirection, (box.bounds.extents.x / 2) + 0.25f, layermask))
            {
                return true;
            }
        }
        return false;
    }

    bool CheckVerticalCollision()
    {
        float dist = (box.bounds.extents.x * 2) / VerticalRayCount;
        VerticalDirection.x = 0;
        if(movement.y <= 0)
        {
            VerticalDirection.y = -1;
        }
        else
        {
            VerticalDirection.y = 1;
        }
        VerticalDirection.y = -1;
        Vector2 rayStartPosition = new Vector2(0, 0);
        for (int i = 0; i < VerticalRayCount + 1; i++)
        {
            rayStartPosition.x = this.transform.position.x - box.bounds.extents.x + (dist * i);
            rayStartPosition.y = this.transform.position.y + box.bounds.extents.y;
            if (Physics2D.Raycast(rayStartPosition, VerticalDirection, (box.bounds.extents.y) + 0.1f, layermask))
            {
                return true;
            }
        }
        return false;
    }

    void OnJump()
    {
        if(CheckVerticalCollision())
        {
            rb.AddForce(new Vector2(0, jumpPower));
        }
    }

    void OnHorizontal(InputValue value)
    {
        m_fHorizontalInput = value.Get<float>();
    }

    void OnShoot()
    {
        gun.Fire();
    }

}
