using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour
{
    private Rigidbody2D rb2;
    public bool isUp;
    public Vector3 position;
    public Vector2 throw_force = new Vector2(2000, 2000);
    public Collider2D pickupCol;
    public GameObject map;
    public GameObject picked;

    public bool pressed_key = false;
    
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        isUp = false;
    }

    void Update()
    {
        if(this.transform.localScale.x > 0)
        {
            position.x = 1.5f;
            throw_force.x = 2000;
        }
        if(this.transform.localScale.x < 0)
        {
            position.x = -1.5f;
            throw_force.x = -2000;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            pressed_key = true;
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            pressed_key = false;
        }
        if(isUp)
        {
            picked.transform.position = this.transform.position + position;
            if(pressed_key)
            {
                picked.GetComponent<thowables>().is_picked = false;
                picked.GetComponent<thowables>().is_thrown = true;
                picked.gameObject.transform.SetParent(map.transform);
                picked.GetComponent<Rigidbody2D>().gravityScale = 10;
                picked.GetComponent<Rigidbody2D>().freezeRotation = false;
                picked.GetComponent<Rigidbody2D>().AddForce(throw_force);
                isUp = false;
                picked = null;
                pressed_key = false;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(pressed_key && pickupCol.IsTouching(other) && !isUp && other.gameObject.tag == "throwable")
        {
            picked = other.gameObject;
            picked.GetComponent<thowables>().is_picked = true;
            other.attachedRigidbody.freezeRotation = true;
            other.gameObject.transform.SetParent(this.gameObject.transform);
            other.attachedRigidbody.gravityScale = 0;
            other.transform.position = other.transform.position + position;
            isUp = true;
            pressed_key = false;
            return;
        }
        else if(pressed_key && pickupCol.IsTouching(other) && isUp)
        {
            
        }
    }
}
