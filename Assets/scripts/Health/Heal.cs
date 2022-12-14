
using UnityEngine;

public class Heal : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip sound;


    public int healthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            player_health.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }
    }


}
