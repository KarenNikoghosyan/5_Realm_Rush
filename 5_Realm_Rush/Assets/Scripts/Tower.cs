using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 45f;
    [SerializeField] ParticleSystem projectileParticle;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null) { 
            SetGunsActive(false); 
            return; 
        }

        objectToPan.transform.LookAt(targetEnemy);
        FireAtEnemy();

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
