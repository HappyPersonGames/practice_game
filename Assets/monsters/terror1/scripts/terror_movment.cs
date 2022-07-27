using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror_movment : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 200f; 
    public bool isDetected = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
        isDetected = GetComponent<shooting>().isDetected;
        if(GetComponent<terror1>().state == State.idle)
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime,0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if(GetComponent<terror1>().state != State.picked_up)
        {
            if(speed < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else if(speed > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "player_pickup")
        {
            speed *= -1;
            
        }

    }
    
    
}
