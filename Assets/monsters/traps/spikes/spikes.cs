using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public float damage = 40f;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInParent<combat>().do_damage(damage, (other.transform.position - transform.position)*1000);
        }
        if(other.tag == "throwable")
        {
            other.GetComponentInParent<thowables>().do_damage_knockback(damage, (other.transform.position - transform.position)*1000);
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "throwable")
            other.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1000, 0));
    }

}
