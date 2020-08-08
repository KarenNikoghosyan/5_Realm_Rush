using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] ParticleSystem baseExplosion;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health = health-healthDecrease;
        }    
        if(health <= 0)
        {
            //var vfx = Instantiate(baseExplosion, transform.position, Quaternion.identity);
            //vfx.Play();
            //Destroy(gameObject);
        }
    }
}
