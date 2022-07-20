using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class terror1 : thowables
{
    public float health = 100;
    public Material dead;
    public bool isDetected = false;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if(this.gameObject.GetComponentInChildren<SpriteRenderer>().material != dead)
            {
                Destroy(gameObject, 5);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().material = dead;
                this.tag = "Untagged";
            }
        }
        if(state == State.thrown)
        {
            if(damage < 30f)
                damage += 0.1f;
        }
        else
        {
            damage = 0;
        }
        set_state();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "throwable")
        {
            health -= other.GetComponent<thowables>().damage;
            Debug.Log(name + " got " + other.GetComponent<thowables>().damage + " from "+ other.name);
        }

        if(state == State.thrown)
        {
            health -= damage;
            Debug.Log(name + " got " + damage + " fall damage");
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
        else if(GetComponent<BoxCollider2D>().IsTouchingLayers(layerMask))
        {
            Debug.Log("idle");
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
            state = State.thrown;
        }
        p += " after: " + state.ToString();
        // Debug.Log(p);
    }

    void get_state()
    {

    }
    
}
