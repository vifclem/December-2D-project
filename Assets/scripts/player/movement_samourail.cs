using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class movement_samourail : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 2f;
    public Rigidbody2D rb;
    public Animator anim;
    public CapsuleCollider2D playerCollider;
    public bool isClimbing;
    public bool isGrounded;

    
    public static movement_samourail instance;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de movementSamourail dans la scene");
            return;
        }
        instance = this;
    }







    private void Start()
    {
        //Grab references for rigidBody and animator
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
   
    
    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        var movement = horizontalInput;
        var movementy = verticalInput;

        if (!isClimbing)
        {
            //move right and left 
           
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

            // Jump
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            //deplacement vertical
            transform.position += new Vector3(movementy, 0, 0) * Time.deltaTime * speed;

        }

      



        //flip character on x
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //set animator parametres
        anim.SetBool("run", horizontalInput != 0);

    }

    
    



}
