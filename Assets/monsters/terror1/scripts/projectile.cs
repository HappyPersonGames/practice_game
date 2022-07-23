using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private float damage = 15;
    private GameObject[] players;

    public void set_target(Vector3 target)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Vector3 force = calcBallisticVelocityVector(transform.position, target);
        if(!force.Equals(new Vector3(float.NaN,float.NaN,float.NaN)))
        {
            Debug.Log(force +" " + target + " " + transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
        gameObject.tag = "pain_ball";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInParent<combat>().health -= damage;
        }
        if(other.tag != "throwable" && other.tag != "player_pickup")
            Destroy(this.gameObject);
    }

    Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target)
    {
        target = new Vector3(target.x,target.y + 1, target.z);
        Vector3 direction = target - source;
        float velocity = 1000f; 
        return velocity * direction.normalized;    

     }
}
