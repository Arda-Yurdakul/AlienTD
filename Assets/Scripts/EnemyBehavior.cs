using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;



[DisallowMultipleComponent]
public class EnemyBehavior : MonoBehaviour
{
    private List<Waypoint> path;

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
            transform.position = block.transform.position + new Vector3(0,5,0);
            yield return new WaitForSeconds(1.0f);
        }
        print("Patrol finished..");
        
    }

}
