using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite full;
    public Sprite threeQ;
    public Sprite half;
    public Sprite oneQ;
    public Sprite empty;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hp = 0;
        if(GetComponent<thowables>() != null)
            hp = GetComponent<thowables>().get_damage();
        else if(GetComponent<combat>() != null)
            hp = GetComponent<combat>().get_damage();
        
        update_health_bar(hp);

    }

    public void update_health_bar(float health)
    {
        if(health > 75)
            sr.sprite = full;
        else if(health > 50)
            sr.sprite = threeQ;
        else if(health > 25)
            sr.sprite = half;
        else if(health > 0)
            sr.sprite = oneQ;
        else
            sr.sprite = empty;
    }
}
