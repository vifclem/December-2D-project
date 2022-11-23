
using UnityEngine;

public class frog_damage : MonoBehaviour
{
    public int attackDamage = 10; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player_health PlayerHealth = collision.transform.GetComponent<player_health>();
            PlayerHealth.TakeDamage(attackDamage);
        }
    }
}
