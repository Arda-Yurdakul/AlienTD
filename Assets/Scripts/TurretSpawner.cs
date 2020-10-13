using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{

    private Queue<Waypoint> waypoints = new Queue<Waypoint>();
    private Queue<GameObject> turrets = new Queue<GameObject>();
    [SerializeField] private int maxTurrets;
    [SerializeField] private GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleTurretSpawn(Waypoint waypoint)
    {
        if(waypoints.Count != maxTurrets)
        {
            GameObject myTurret = Instantiate(turret, waypoint.transform.position + new Vector3(0,10,0), Quaternion.identity);
            turrets.Enqueue(myTurret);
            myTurret.transform.parent = this.transform;
            waypoints.Enqueue(waypoint);
            waypoint.hasTower = true;
            turret.name = waypoints.Count.ToString();
        }
        else
        {
            Waypoint oldestWaypoint = waypoints.Dequeue();
            GameObject myTurret = turrets.Dequeue();
            oldestWaypoint.hasTower = false;
            myTurret.transform.position = waypoint.transform.position + new Vector3(0, 10, 0);
            print(myTurret.name);
            waypoint.hasTower = true;
            turrets.Enqueue(myTurret);
            waypoints.Enqueue(waypoint);
        }
    }
}
