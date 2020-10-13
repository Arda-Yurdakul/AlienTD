using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    private const int snapSize = 10;
    public bool hasTower;
    public bool isExplored;
    public Waypoint exploredFrom;
    [Header("Turret Settings")]
    [SerializeField] private GameObject turret;


    [Header("Cursor Images")]
    [SerializeField] private Texture2D buildArrow;
    [SerializeField] private Texture2D regularArrow;



    // Start is called before the first frame update
    void Start()
    {
        isExplored = false;
        hasTower = false;
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

    void OnMouseOver()
    {
        if (this.gameObject.CompareTag("Neutral") && !hasTower)
        {
            Cursor.SetCursor(buildArrow, Vector2.zero, CursorMode.ForceSoftware);
            if(Input.GetMouseButtonDown(0))
                FindObjectOfType<TurretSpawner>().HandleTurretSpawn(this);
        }

        else
        {
            Cursor.SetCursor(regularArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(regularArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

}
