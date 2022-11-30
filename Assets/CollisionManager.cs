
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            collision.GetComponent<Ladders>().isInRange = true;
            //InteractUI.enabled = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Ladder"))
        {
            Ladders ladders = collision.GetComponent<Ladders>();
            ladders. isInRange = false;
            ladders.playerMovment.isClimbing = false;
            ladders.topCollider.isTrigger = false;
            //InteractUI.enabled = false;
        }
    }
}
