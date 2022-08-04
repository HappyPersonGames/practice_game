using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    public bool should_shoot = false;
    private float curr;
    public float cool_down;
    public bool isDetected = false;
    public GameObject[] players;
    public LayerMask player;
    public float damage;

    public float range;
    
    // Start is called before the first frame update
    void Start()
    {
        curr = Time.fixedTime;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        combat target = playerDetection();   
        if(GetComponent<terror2>().state == State.attack && Time.fixedTime - curr > cool_down)
        {
            curr = Time.fixedTime;
            should_shoot = false;
            if(target != null)
                attack(target);  
            should_shoot = true;
        }
    }

    private void attack(combat target)
    {
        target.do_damage(damage);

    }

    combat playerDetection()
    {
        foreach (var item in players)
        {
            Debug.DrawRay(transform.position,item.transform.position - transform.position, Color.green);
            if(Physics2D.Raycast(transform.position,item.transform.position - transform.position, range,player))
            {
                isDetected = true;
                return item.GetComponent<combat>();
            }
        }
        isDetected = false;
        return null;
    }
}
