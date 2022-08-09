using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private int number_of_created_entities = 0;
    public List<GameObject> living_entities = new List<GameObject>();
    private float cooldown_timer;
    private bool is_ready = true;
    private float last_spawn;
    
    public void Update()
    {
        if(!is_ready && Time.fixedTime > last_spawn + cooldown_timer)
        {
            is_ready = true;
        }
        foreach(GameObject t in living_entities)
        {
            if(!t.active)
            {
                living_entities.Remove(t);
            }
        }
        Debug.Log(gameObject.name + "  " + living_entities.Count);
    }

    public GameObject spawn(GameObject prefabe_to_spawn)
    {
        if(is_ready)
        {
            last_spawn = Time.fixedTime;
            is_ready = false;
            GameObject spawned = Instantiate(prefabe_to_spawn,transform.position,Quaternion.identity);
            number_of_created_entities++;
            living_entities.Add(spawned);
            return spawned;
        }
        return null;

    }

    public int get_entities_total_count()
    {
        return number_of_created_entities;
    }

    public int get_entities_current_count()
    {
        return living_entities.Count;
    }

    public void set_cooldown(float cooldown)
    {
        cooldown_timer = cooldown;
    }
}
