using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class movement_samourail : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 2f;
    private Rigidbody2D _rigidbody;
    private Animator anim;
   

    private void Start()
    {
        //Grab references for rigidBody and animator
        _rigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //move right and left 
        var movement = horizontalInput;
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;




        // Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
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
