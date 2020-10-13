using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header ("Wave Settings")]
    [SerializeField] private int waveLength;
    [SerializeField] [Tooltip("In Seconds")] [Range(1.0f, 10.0f)] private float spawnDelay;

    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        int spawned = 0;
        yield return new WaitForSeconds(1.0f);

        while(spawned < waveLength)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = this.transform;
            spawned++;
            yield return new WaitForSeconds(spawnDelay);

        }
    }
}
