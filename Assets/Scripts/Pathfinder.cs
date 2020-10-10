using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
    Queue<Waypoint> waypoints = new Queue<Waypoint>();
    Vector3Int[] neighbors = { new Vector3Int(0,0,1), new Vector3Int(1, 0, 0), new Vector3Int(0, 0,-1 ), new Vector3Int(-1, 0, 0) };


    [SerializeField]List<Waypoint> startEnd;
    private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        Pathfind();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Pathfind()
    {
        waypoints.Enqueue(startEnd[0]);
        StopIfEndFound(startEnd[0]);
        while (waypoints.Count > 0 && isRunning)
        {
            Waypoint searchCenter = waypoints.Dequeue();
            searchCenter.isExplored = true;
            StopIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);

        }

    }

    private void StopIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == startEnd[1])
        {
            isRunning = false;
        }
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            if (!grid.ContainsKey(waypoint.GetGridPos()))
                grid.Add(waypoint.GetGridPos(), waypoint);
            else
                Debug.LogWarning("Overlapping blocks!");
        }

        startEnd[0].transform.Find("Quad0").GetComponent<MeshRenderer>().material.color = Color.green; 
        startEnd[1].transform.Find("Quad0").GetComponent<MeshRenderer>().material.color = Color.red;
        
    }

    private void ExploreNeighbors(Waypoint searchCenter)
    {
        if(!isRunning) { return; }
        foreach(Vector3Int dir in neighbors)
        {
            var neighbor = dir + Vector3Int.FloorToInt(searchCenter.GetGridPos());
            try
            {
                Waypoint currentBlock = grid[neighbor];
                if(!currentBlock.isExplored && !waypoints.Contains(currentBlock))
                {
                    currentBlock.transform.Find("Quad0").GetComponent<MeshRenderer>().material.color = Color.blue;
                    waypoints.Enqueue(currentBlock);
                    currentBlock.exploredFrom = searchCenter;
                    Debug.Log("Exploring " + neighbor.ToString());
                }
                

            }
            catch
            {
                Debug.Log("No edge found!");
            }
        }
    }
}
