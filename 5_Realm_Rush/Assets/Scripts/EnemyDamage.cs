using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] int hitPoints = 20;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if(hitPoints <= 0)
        {
            EnemyKill();
        }
    }

    private void ProcessHits()
    {
        hitPoints--;
        hitParticlePrefab.Play();
        AudioManager.instance.Play("Enemy Hit SFX");
    }

    private void EnemyKill()
    {
        ParticleSystem fx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        fx.transform.parent = GameObject.Find("Spawned On Death").transform;
        fx.Play();
        AudioManager.instance.Play("Enemy Death SFX");
        Destroy(gameObject);
    }
}
