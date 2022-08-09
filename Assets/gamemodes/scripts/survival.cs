using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survival : MonoBehaviour
{
    // Start is called before the first frame update
    private const int MAX_ENEMIES = 5;
    [SerializeField]
    private GameObject terrorPrefab;
    private float spawnTimer = 5f;
    public int numOfEnemies;
    public spawner[] spawners;
    void Start()
    {
        spawners = GetComponentsInChildren<spawner>();
        // StartCoroutine(spawnEnemy(spawnTimer,terrorPrefab));
        foreach (spawner s in spawners)
        {
            s.set_cooldown(2);
        }

    }

    void Update()
    {
        int temp = numOfEnemies;
        numOfEnemies = 0;
        foreach (spawner s in spawners)
        {
            if(temp <= MAX_ENEMIES)
            {
                s.spawn(terrorPrefab);
            }
            numOfEnemies += s.get_entities_current_count();
        }
    }

    // private IEnumerator spawnEnemy(float spawnTimer, GameObject enemy)
    // {
    //     yield return new WaitForSeconds(spawnTimer);
    //     // Debug.Log(numOfEnemies);
    //     if(numOfEnemies < MAX_ENEMIES)
    //     {
    //         StartCoroutine(spawnEnemy(spawnTimer,enemy));
    //         // numOfEnemies+=2;
    //     }
    // }
}
