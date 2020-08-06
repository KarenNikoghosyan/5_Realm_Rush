using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tower : MonoBehaviour
{
    // Parameteres of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 45f;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint; // What the tower is standing on

    // State of each tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy == null) { 
            SetGunsActive(false); 
            return; 
        }

        objectToPan.transform.LookAt(targetEnemy);
        FireAtEnemy();

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetCloseEnemy(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetCloseEnemy(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transformA.position, gameObject.transform.position);
        var distToB = Vector3.Distance(transformB.position, gameObject.transform.position);

        if (distToB < distToA)
        {
            return transformB;
        }
        else
        {
            return transformA;
        }

    }

    private void FireAtEnemy()
    {
        if (Vector3.Distance(targetEnemy.position, gameObject.transform.position) <= attackRange)
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
