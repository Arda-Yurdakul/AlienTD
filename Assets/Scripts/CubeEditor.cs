using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    
    TextMesh textMesh;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>(); 
    }


    void Update()
    {
        SnapToGrid();
        SetLabel();
    }


    private void SnapToGrid()
    {
        int snapSize = waypoint.GetSnapSize();
        Vector3 snapPos = waypoint.GetGridPos();
        transform.position = snapPos * waypoint.GetSnapSize();
    }


    private void SetLabel()
    {
        Vector3 snapPos = waypoint.GetGridPos();
        string labelText = snapPos.x  + "," + snapPos.z ;
        name = "Cube (" + labelText + ")";
    }
}
