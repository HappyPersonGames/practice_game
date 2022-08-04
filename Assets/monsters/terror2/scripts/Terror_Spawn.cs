using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terror_Spawn : MonoBehaviour
{
    private const int MAX_ENEMIES = 5;
    [SerializeField]
    private GameObject terrorPrefab;
    private float spawnTimer = 5f;
    public int numOfEnemies = 2;
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimer,terrorPrefab));
    }

    private IEnumerator spawnEnemy(float spawnTimer, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTimer);
        Debug.Log(numOfEnemies);
        if(numOfEnemies < MAX_ENEMIES)
        {
            GameObject newEnemy = Instantiate(enemy,transform.position,Quaternion.identity);
            StartCoroutine(spawnEnemy(spawnTimer,enemy));
            numOfEnemies+=2;
        }
    }
}
