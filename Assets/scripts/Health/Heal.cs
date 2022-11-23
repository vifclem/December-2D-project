
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_health.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }
    }
}
