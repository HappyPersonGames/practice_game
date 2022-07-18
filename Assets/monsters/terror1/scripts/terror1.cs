using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror1 : MonoBehaviour
{
    public float health = 100;
    public Material dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if(this.gameObject.GetComponentInChildren<SpriteRenderer>().material != dead)
            {
                Destroy(gameObject, 5);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().material = dead;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        thowables throwable = (thowables)other.GetComponent<thowables>();
        Debug.Log("hit");
        if(other.tag == "throwable" && throwable.movement)
        {
            health -= other.GetComponent<thowables>().damage;
        }

        if(GetComponent<thowables>().is_thrown && other.tag != "player_pickup")
        {
            GetComponent<thowables>().is_thrown = false;
            health -= this.GetComponent<thowables>().damage;
        }
    }
}
