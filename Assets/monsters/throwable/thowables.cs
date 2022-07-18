using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thowables : MonoBehaviour
{
    public float damage = 10;
    public bool movement = false;
    // Start is called before the first frame update
    private Vector3 last_pos = new Vector2(0,0);
    public bool is_thrown = false;
    void Start() 
    {
        damage *= this.GetComponent<Rigidbody2D>().mass;    
    }

    void FixedUpdate() 
    {
        if(this.transform.position.x == last_pos.x && this.transform.position.y == last_pos.y)
        {
            movement = false;
            // is_thrown = false;
        }
        else
        {
            movement = true;
        }
        last_pos = this.transform.position;
    }
}
