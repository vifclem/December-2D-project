using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip sound;
    public int maxHealth = 50;
    int currentHealth;



   
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        AudioSource.PlayClipAtPoint(sound, transform.position);

        Destroy(gameObject);
        Debug.Log("enemy died");
        
    }

    

    
}
