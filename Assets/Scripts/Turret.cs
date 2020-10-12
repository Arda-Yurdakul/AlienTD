using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform enemy;
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
        enemy = GetEnemies();
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

    private Transform GetEnemies()
    {
        var enemies = FindObjectsOfType<EnemyBehavior>();
        if (enemies.Length == 0)
        {
            print("NO enemies present");
            return null;
        }

        Transform result = enemies[0].transform;
        float closestDist = Vector3.Distance(transform.position, result.position);
        foreach(EnemyBehavior enemy in enemies)
        {
            float enemyDist = Vector3.Distance(transform.position, enemy.transform.position);
            if ( enemyDist < closestDist)
            {
                result = enemy.transform;
                closestDist = enemyDist;
            }

        }

        return result;
    }
}
