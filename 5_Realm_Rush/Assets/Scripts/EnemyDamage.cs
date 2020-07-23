using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 5;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if(hits <= 0)
        {
            EnemyKill();
        }
    }

    private void ProcessHits()
    {
        hits--;
    }

    private void EnemyKill()
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
