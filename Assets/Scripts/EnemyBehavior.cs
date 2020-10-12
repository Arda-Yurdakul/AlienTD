using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;



[DisallowMultipleComponent]
public class EnemyBehavior : MonoBehaviour
{
    private List<Waypoint> path;
    [SerializeField] [Range(1,100)] private int health;
    [SerializeField] private GameObject explosion;
    public Transform runtimeObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FindPath()
    {
        path = FindObjectOfType<Pathfinder>().GetPath();
        print("Starting patrol..");
        foreach(Waypoint block in path)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
        print("Patrol finished..");
        
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
    }

}
