﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask[] whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = false;
        for (int i = 0; i < whatIsGround.Length; i++)
        {
            if (Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround[i]))
            {
                isGrounded = true;
                //Debug.Log("Grounded");
            }
        }


        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            flip();
        }
         if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        //(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            //Debug.Log("Hello");
        }
        else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true)
        //(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            //Debug.Log("hi");
            rb.velocity = Vector2.up * jumpForce;
        }
    }

        

    // void update()
    // {
    //      if(isGrounded == true)
    //     {
    //         extraJumps = extraJumpValue;
    //     }

    //     if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
    //     {
    //         rb.velocity = Vector2.up * jumpForce;
    //         extraJumps--;
    //         Debug.Log("Hello");
    //     }
    //     else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
    //     {
    //         Debug.Log("hi");
    //         rb.velocity = Vector2.up * jumpForce;
    //     }
    // }

       
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Lava" && gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        else if(col.gameObject.tag=="Water" && gameObject.tag == "Child")
        {
            //Debug.Log("Water");
            int childPos = gameObject.GetComponent<ChangeController>().thisPos - 2;
            Debug.Log(childPos);
            GameObject.FindWithTag("Player").GetComponent<SpawnChild>().DestroyChild(childPos);
        }
        else
        {

        }
    }
}
