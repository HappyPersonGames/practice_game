using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{idle, thrown, picked_up, attack, dead}

public class thowables : MonoBehaviour
{
    public float damage;
    // public bool movement = false;
    // Start is called before the first frame update
    // private Vector3 last_pos = new Vector2(0,0);
    public bool is_thrown = false;
    public bool is_picked = false;
    

    public LayerMask layerMask;

    public State state;
    void Start() 
    {
        // damage *= this.GetComponent<Rigidbody2D>().mass;
        state = State.idle;
    }

    void Update() 
    {
        // if(GetComponent<BoxCollider2D>().IsTouchingLayers(layerMask))
        // {
        // }
        // else
        // {
            
        // }
        // if(this.transform.position.x == last_pos.x && this.transform.position.y == last_pos.y)
        // {
        //     movement = false;

        //     is_thrown = false;
        // }
        // else
        // {
        //     movement = true;
        // }
        // last_pos = this.transform.position;
        set_state();
        if(state == State.idle || state == State.picked_up)
        {
            damage = 0;
        }
        else if(state == State.thrown)
        {
            damage = 10*this.GetComponent<Rigidbody2D>().mass;
        }

    }

    State get_state()
    {
        return state;
    }

    private void set_state()
    {
        if(GetComponent<BoxCollider2D>().IsTouchingLayers(layerMask))
        {
            state = State.idle;
            is_thrown = false;
        }
        else if(is_picked)
        {
            state = State.picked_up;

        }
        else if(is_thrown)
        {
            state = State.thrown;
            is_picked = false;
        }
        else
        {
            state = State.thrown;
            is_thrown = true;
        }
    }
}
