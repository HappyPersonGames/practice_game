using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour
{
    private Rigidbody2D rb2;
    public bool isUp;
    public Vector3 position = new Vector3(0.2f,3,0);
    public Collider2D pickupCol;
    public GameObject map;
    public GameObject picked;

    public bool pressed_key = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            pressed_key = true;
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            pressed_key = false;
        }
        if(isUp)
        {
            picked.transform.position = this.transform.position + position;
        }

    }

    private void FixedUpdate()
    {
        // pressed_key = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("touching " + Input.GetKeyDown(KeyCode.F) + other.name);
        if(pressed_key && pickupCol.IsTouching(other) && !isUp)
        {
            // Debug.Log("hello");
            picked = other.gameObject;
            other.attachedRigidbody.freezeRotation = true;
            other.gameObject.transform.SetParent(this.gameObject.transform);
            other.attachedRigidbody.gravityScale = 0;
            other.transform.position = other.transform.position + position;
            isUp = true;
            pressed_key = false;
            return;
        }
        else if(pressed_key && pickupCol.IsTouching(other) && isUp)
        {
            // Debug.Log("bye");
            picked.gameObject.transform.SetParent(map.transform);
            other.attachedRigidbody.gravityScale = 10;
            other.attachedRigidbody.freezeRotation = false;
            other.attachedRigidbody.AddForce(new Vector2(1000, 1000));
            isUp = false;
            picked = null;
            pressed_key = false;
        }
    }
}
