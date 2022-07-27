using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projctile;
    public bool should_shoot = false;
    private float curr;
    public float cool_down;
    public bool isDetected = false;
    public GameObject[] players;
    public LayerMask player;

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
        Vector3 target = playerDetection();   
        if(GetComponent<terror1>().state == State.attack && Time.fixedTime - curr > cool_down)
        {
            curr = Time.fixedTime;
            should_shoot = false;
            if(!target.Equals(new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity)))
                shoot(target);  
            should_shoot = true;
        }
    }

    private void shoot(Vector3 target)
    {
        float projX = (target.x - transform.position.x)/MathF.Abs((target.x - transform.position.x));
        GameObject spawned_proj = Instantiate(projctile, new Vector3(transform.position.x+projX, transform.position.y + 1f, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
        spawned_proj.AddComponent<projectile>().set_target(target);
    }

    Vector3 playerDetection()
    {
        foreach (var item in players)
        {
            Debug.DrawRay(transform.position,item.transform.position - transform.position, Color.green);
            if(Physics2D.Raycast(transform.position,item.transform.position - transform.position, range,player))
            {
                isDetected = true;
                return item.transform.position;
            }
        }
        isDetected = false;
        return new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity);
    }
}
