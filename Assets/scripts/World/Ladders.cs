using UnityEngine;
using UnityEngine.UI;

public class Ladders : MonoBehaviour
{
    public bool isInRange;
    public movement_samourail playerMovment;
    public BoxCollider2D topCollider;
    public Text InteractUI;
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
            topCollider.isTrigger = true;
            return;
        }

       if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovment.isClimbing = true;
            topCollider.isTrigger = false;
        }
    }

    
}