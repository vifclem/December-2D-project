using UnityEngine;
using System.Collections;

public class player_health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvicible = false;
    public float InvicibilityFlashDelay = 0.2f;
    public float invicibilityTimeAfterHit = 3f;
    public SpriteRenderer graphics;


    public Health_bar healthBar;
    public static player_health instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de playerHealth dans la scene");
            return;
        }
        instance = this;
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }
    public void HealPlayer(int amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }


    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
       
    }

    public void Die()
    {
        Debug.Log("joueur eliminé");
        movement_samourail.instance.enabled = false;
        movement_samourail.instance.anim.SetTrigger("die");
        movement_samourail.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        movement_samourail.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();

    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds (InvicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
