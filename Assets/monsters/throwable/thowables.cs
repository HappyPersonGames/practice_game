using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{idle, thrown, picked_up, attack, dead, defualt}

public class thowables : MonoBehaviour
{
    public float damage;
    public bool is_thrown = false;
    public bool is_picked = false;
    

    public LayerMask layerMask;

    public State state;
    void Start() 
    {
        state = State.idle;
    }

    void Update() 
    {
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

    public virtual void do_damage(float damage)
    {
        
    }

    public void do_damage_knockback(float damage, Vector3 knock_back)
    {
        do_damage(damage);
        GetComponent<Rigidbody2D>().AddForce(knock_back);
    }
}
