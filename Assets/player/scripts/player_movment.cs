using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_movment : MonoBehaviour
{
    private Rigidbody2D rb2;

    private float horizontal_movement;
    public bool jump;
    public bool is_in_air;

    public Collider2D jumpCollider;

    public float speed = 10;
    public float jump_force = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_movement = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {   
        rb2.velocity = new Vector2(horizontal_movement * speed, 0);
        if(jump && !is_in_air)
        {
            Debug.Log("jump");
            rb2.AddForce(new Vector2(0f, 100f * jump_force));
        }
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(jumpCollider.IsTouching(other));
        if((other.gameObject.tag == "platform" || other.gameObject.tag == "throwable") && jumpCollider.IsTouching(other))
        {
            is_in_air = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if((other.gameObject.tag == "platform") && !jumpCollider.IsTouching(other))
        {
            is_in_air = true;
        }
    }
}
