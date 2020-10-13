using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.MemoryProfiler;
using UnityEngine;



[DisallowMultipleComponent]
public class EnemyBehavior : MonoBehaviour
{
    private List<Waypoint> path;
    private Waypoint block;
    private Waypoint nextBlock;
    private float moveSpeed;

    [SerializeField] [Range(1,100)] private int health;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject hitEffect;
   

    public Transform runtimeObjects;
   

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        StartCoroutine(FindPath());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist = nextBlock.transform.position -  block.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dist, moveSpeed * Time.deltaTime);
    }

    public IEnumerator FindPath()
    {
        path = FindObjectOfType<Pathfinder>().GetPath();
        for(int i=0; i<path.Count; i++)
        {
            block = path[i];
            if((i + 1) < path.Count)
                nextBlock = path[i + 1];
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if(health <= 0)
        {
            GameObject explosionParticle = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionParticle.transform.parent = runtimeObjects;
            Destroy(this.gameObject);
        }
        else
        {
           GameObject hitParticle = Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

}
