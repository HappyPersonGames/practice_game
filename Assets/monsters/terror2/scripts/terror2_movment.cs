using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror2_movment : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 200f; 
    public GameObject target;
    
    private Vector2 last_pos;
    public float jump_cooldown = 0.2f;
    public float last_jump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        last_jump = Time.fixedTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<terror2>().state == State.idle)
        {
            find_target();

            rb.velocity =   (target.transform.position - transform.position);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
        }
        if(GetComponent<terror2>().state != State.picked_up)
        {
            if(speed < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else if(speed > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }

    void FixedUpdate()
    {
        if(GetComponent<terror2>().state == State.idle)
        {
            if(Vector3.Distance(last_pos, transform.position) < 0.1)
            {
                
                jump();
            }
        }
        last_pos = transform.position;

    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.tag != "player_pickup")
    //     {
    //         speed *= -1;
            
    //     }

    // }

    public void find_target()
    {
        float smallest = 9999f;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(Mathf.Abs(Vector3.Distance(item.transform.position, transform.position)) < smallest)
            {
                smallest = Mathf.Abs(Vector3.Distance(item.transform.position, transform.position));
                target = item;
            }
        }
    }

    public void jump()
    {
        Debug.Log("jump");
        // if(Time.fixedTime - last_jump > jump_cooldown)
        // {
            rb.AddForce(new Vector2(0, 7000));
            last_jump = Time.fixedTime;
        // }
    }
}
