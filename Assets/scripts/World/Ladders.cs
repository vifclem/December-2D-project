using UnityEngine;
using UnityEngine.UI;

public class Ladders : MonoBehaviour
{
    private bool isInRange;
    private movement_samourail playerMovment;
    //public BoxCollider2D topCollider;
   // private Text InteractUI;
    void Awake()
    {
        //InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        playerMovment = GameObject.FindGameObjectWithTag("Player").GetComponent<movement_samourail>();
    }

    void Update()
    {
        if (isInRange && playerMovment.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovment.isClimbing = true;
            //topCollider.isTrigger = false;
           // return;
        }

       //if (isInRange && Input.GetKeyDown(KeyCode.E))
        //{
            //playerMovment.isClimbing = true;
           // topCollider.isTrigger = true;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //InteractUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            //playerMovment.isClimbing = false;
            //topCollider.isTrigger = false;
            //InteractUI.enabled = false;
        }
    }
}