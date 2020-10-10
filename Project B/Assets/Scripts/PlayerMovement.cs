using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    float movespeed;
    public Rigidbody2D rb;
    bool isFacingRight;
    Vector2 movement;
    Animator anima;
    bool standRight;
    bool standUp;
    bool standDown;
    bool Stand;



    private void Start()
    {
        anima = gameObject.GetComponent<Animator>();
        Stand = true;
        standRight = true;
        standUp = false;
        standDown = false;
        isFacingRight = true;

    }


    private void LateUpdate()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 4f;
        }
        else
        {
            movespeed = 2.5f;
        }

       
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);



        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isFacingRight = true;
            Flip();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isFacingRight = false;
            Flip();
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            Stand = true;
        }
        else
        {
            Stand = false;
        }

        if (!Stand)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                anima.Play("WalkRightAnima");
                standRight = true;
                standUp = false;
                standDown = false;
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anima.Play("WalkUpAnima");
                standRight = false;
                standUp = true;
                standDown = false;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anima.Play("WalkDownAnima");
                standRight = false;
                standUp = false;
                standDown = true;
            }

        }
        else
        {
            if(standRight)
            {
                anima.Play("StandRightAnima");
            }
            else if(standUp)
            {
                anima.Play("StandUpAnima");
            }
            else if(standDown)
            {
                anima.Play("StandDownAnima");
            }
        }
        


        
    }


    // Flip Player over the x-axis
    protected void Flip()
    {
            if (isFacingRight)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
    } 
}
