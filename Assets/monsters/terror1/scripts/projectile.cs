using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private float damage = 15;
    private GameObject[] players;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update() 
    {
        // if(GetComponent<Collider2D>().IsTouching())
        // {

        // }    
    }
    public void set_target(Vector3 target)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        gameObject.AddComponent<Rigidbody2D>().AddForce(calcBallisticVelocityVector(transform.position, target));
        // gameObject.AddComponent<CircleCollider2D>().isTrigger = true;
        // gameObject.GetComponent<CircleCollider2D>().radius = 0.55f;
        
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

    void OnTriggerStay2D(Collider2D other)
    {
        
        // Destroy(gameObject, 2);
    }

    Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target)
    {
        Vector3 direction = target - source;
        // direction.y = Mathf.Abs(direction.y);
        float velocity = 1000f; 
        return velocity * direction.normalized;    

     }
}
