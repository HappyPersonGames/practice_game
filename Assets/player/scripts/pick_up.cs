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
    
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUp)
        {
            picked.transform.position = this.transform.position + position;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
        }

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("touching" + Input.GetKeyDown(KeyCode.F));
        if(Input.GetKeyDown(KeyCode.F) && pickupCol.IsTouching(other) && !isUp)
        {
            Debug.Log("hello");
            picked = other.gameObject;
            other.attachedRigidbody.freezeRotation = true;
            other.gameObject.transform.SetParent(this.gameObject.transform);
            other.attachedRigidbody.gravityScale = 0;
            other.transform.position = other.transform.position + position;
            isUp = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && isUp)
        {
            Debug.Log("bye");
            picked = null;
            other.gameObject.transform.SetParent(map.transform);
            isUp = false;
            other.attachedRigidbody.gravityScale = 10;
        }
    }
}
