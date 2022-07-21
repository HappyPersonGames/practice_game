using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror_movment : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 200f; 
    public bool isDetected = false;
    public GameObject[] players;
    public LayerMask player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        playerDitection();
        if(GetComponent<terror1>().state == State.idle)
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime,0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isDetected && other.tag != "player_pickup")
            speed *= -1;

    }
    
    Vector3 playerDitection()
    {
        foreach (var item in players)
        {
            Debug.Log(Physics2D.Raycast(transform.position,item.transform.position - transform.position,5f,player));
            Debug.DrawRay(transform.position,item.transform.position - transform.position, Color.green);
            if(Physics2D.Raycast(transform.position,item.transform.position - transform.position,5f,player))
            {
                isDetected = true;
                return item.transform.position;
            }
        }
        isDetected = false;
        return new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity);
    }
}
