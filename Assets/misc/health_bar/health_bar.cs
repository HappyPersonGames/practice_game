using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite full;
    public Sprite threeQ;
    public Sprite half;
    public Sprite oneQ;
    public Sprite empty;

    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
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
        
        slider.value = (health / 100f);
    }
}
