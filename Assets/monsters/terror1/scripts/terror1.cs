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
            this.gameObject.GetComponentInChildren<SpriteRenderer>().material = dead;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.tag == "throwable" && other.GetComponent<thowables>().movement)
        {
            health -= other.GetComponent<thowables>().damage;
        }
    }
}
