
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class TPfirst : MonoBehaviour
{

    private GameObject samourail;
    public GameObject TP;
    
    

    private void Awake()
    {

        samourail = GameObject.FindWithTag("Player");
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            samourail.transform.position = new Vector2(TP.transform.position.x, TP.transform.position.y);


            StartCoroutine(waiter());
            
        }
    }

    IEnumerator waiter()
    {
        TP.SetActive(false);
        yield return new WaitForSeconds(2f);
        TP.SetActive(true);
    }
}

