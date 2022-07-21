using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class terror1 : thowables
{
    public float health = 100;
    public Material dead;
    public bool isDetected = false;
    private float y_start = 0;
    private float y_end = 0;
    
    // Update is called once per frame
    void Update()
    {
        isDetected = GetComponent<terror_movment>().isDetected;
        if(health <= 0)
        {
            if(this.gameObject.GetComponentInChildren<SpriteRenderer>().material != dead)
            {
                Destroy(gameObject, 5);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().material = dead;
                this.tag = "Untagged";
            }
        }
        else
        {
            damage = 0;
        }
        bool tempState = (state == State.thrown);
        set_state();
        if(tempState && state == State.idle)
        {
            damage = 5*Mathf.Abs(y_start-y_end);
            health -= damage;
            //Debug.Log(name + " got " + damage + " fall damage");
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "throwable")
        {
            health -= other.GetComponent<thowables>().damage;
           // Debug.Log(name + " got " + other.GetComponent<thowables>().damage + " from "+ other.name);
        }
    }

    void set_state()
    {
        string p = "before: " + state.ToString();
        if(health <= 0)
        {
            state = State.dead;
            is_thrown = false;
            is_picked = false;
        }
        else if(GetComponent<BoxCollider2D>().IsTouchingLayers(layerMask) && (!isDetected || state == State.thrown))
        {
            if(state == State.thrown)
                y_end = transform.position.y;
            state = State.idle;
            is_thrown = false;
        }
        else if(is_picked)
        {
            state = State.picked_up;
            isDetected = false;
        }
        else if(is_thrown)
        {
            if(state == State.picked_up)
                y_start = transform.position.y;
            state = State.thrown;
            is_picked = false;
        }
        else if(isDetected)
        {
            state = State.attack;
            is_picked = false;
            is_thrown = false;
        }
        else
        {
            state = State.defualt;
        }
    }

    void get_state()
    {

    }
    
}
