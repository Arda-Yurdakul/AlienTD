using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] private Transform enemy;
    [SerializeField] private float effectiveRange;
    
    ParticleSystem bullets;
    private bool inRange;

    private void Start()
    {
        inRange = false;
        bullets = GetComponentInChildren<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            transform.Find("Top").LookAt(enemy);
            inRange = Vector3.Distance(transform.position, enemy.transform.position) < effectiveRange;
            bullets.gameObject.SetActive(inRange);
        }
        else
        {
            bullets.gameObject.SetActive(false);
        }
        
    }
}
