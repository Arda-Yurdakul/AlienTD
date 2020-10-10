using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private const int snapSize = 10;
    public bool isExplored;
    public Waypoint exploredFrom;
     
    // Start is called before the first frame update
    void Start()
    {
        isExplored = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetSnapSize()
    {
        return snapSize;
    }

    public Vector3Int GetGridPos()
    {
        return new Vector3Int(Mathf.RoundToInt(transform.position.x / snapSize) ,
                                    Mathf.RoundToInt(transform.position.y / snapSize) ,
                                    Mathf.RoundToInt(transform.position.z / snapSize));

    }
}
