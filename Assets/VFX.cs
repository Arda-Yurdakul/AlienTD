using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var explosions = FindObjectsOfType<Explosion>();
        foreach(Explosion explosion in explosions) {
            {
                explosion.transform.parent = transform;
            } }
    }
}
