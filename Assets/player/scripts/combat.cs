using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    public float health = 100f;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            death();
        }
    }

    void death()
    {
        Destroy(gameObject);
    }

    public void do_damage(float damage)
    {
        health -= damage;
    }

    public void do_damage(float damage, Vector3 knock_back)
    {
        health -= damage;
        GetComponent<Rigidbody2D>().AddForce(knock_back);
    }

    public float get_damage()
    {
        return health;
    }
}
