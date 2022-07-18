using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projctile;
    public bool should_shoot = true;
    private float curr;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        curr = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if(should_shoot && Time.fixedTime - curr > 3 && players.Length > 0 && GetComponent<terror1>().health > 0)
        {
            curr = Time.fixedTime;
            should_shoot = false;
            shoot();  
            should_shoot = true;
        }
    }

    private void shoot()
    {
        Debug.Log("shoot");
        GameObject spawned_proj = Instantiate(projctile, new Vector3(transform.position.x, transform.position.y + 0.7f, 0f), transform.rotation);
        spawned_proj.AddComponent<Rigidbody2D>().AddForce(calcBallisticVelocityVector(transform.position, players[0].transform.position));
        spawned_proj.tag = "pain_ball";
        Destroy(spawned_proj, 10);   

    }

    Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target)//, float angle)
    {
        Vector3 direction = target - source;
        direction.y = Math.Abs(direction.y);
        float velocity = 1000f; 
        //  float h = direction.y;                                           
        //  direction.y = 0;                                               
        //  float distance = direction.magnitude;                           
        //  float a = angle * Mathf.Deg2Rad;                                
        //  direction.y = distance * Mathf.Tan(a);                            
        //  distance += h/Mathf.Tan(a);                                      
 
        //  // calculate velocity
        //  float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2*a));
        return velocity * direction.normalized;    

     }
}
