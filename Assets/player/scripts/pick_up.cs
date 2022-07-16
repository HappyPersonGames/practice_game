using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private bool isUp;
    public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        isUp = false;
        position = new Vector2(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

    }

     private void OnTriggerExit2D(Collider2D collider)
    {
        
    }
}
