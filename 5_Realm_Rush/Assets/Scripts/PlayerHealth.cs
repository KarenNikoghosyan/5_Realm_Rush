using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] ParticleSystem baseExplosion;
    [SerializeField] Text healthText;
    [SerializeField] float loadLevelDelay = 1.5f;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health -= healthDecrease;
            healthText.text = health.ToString();
        }    
        if(health <= 0)
        {
            var vfx = Instantiate(baseExplosion, transform.position, Quaternion.identity);
            vfx.Play();
            Invoke("ReloadLevelOnDeath", loadLevelDelay);
        }
    }
    private void ReloadLevelOnDeath()
    {
        SceneManager.LoadScene(0);
    }
}
