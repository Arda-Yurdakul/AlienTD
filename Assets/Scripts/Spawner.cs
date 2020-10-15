using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private int[] waveLengths;
    [SerializeField] [Tooltip("In Seconds")] private float[] spawnDelays;
    [SerializeField] [Tooltip("In Seconds")] private float downTime;
    

    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

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
        yield return new WaitForSeconds(3.0f);

        for(int i=0; i<waveLengths.Length; i++)
        {
            while (spawned < waveLengths[i])
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.parent = this.transform;
                spawned++;
                yield return new WaitForSeconds(spawnDelays[i]);

            }

            if(i!=waveLengths.Length -1)
            {
                FindObjectOfType<WaveHandler>().HandleWave(i);
                spawned = 0;
                yield return new WaitForSeconds(downTime);
            }
            
            
        }

        FindObjectOfType<WaveHandler>().HandleWave(waveLengths.Length);
        GameObject boss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
        boss.transform.parent = this.transform;

    }
}
