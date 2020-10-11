using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //Player's body variable
    public Rigidbody2D rb;

    //Movement variables
    Vector2 movement;
    float movespeed;

    //Animations variables
    Animator anima;
    bool isFacingRight;    
    bool standRight;
    bool standUp;
    bool standDown;
    bool Stand;

    //Stamina Bar variables
    float Stamina;
    public GameObject staminaBar;




    void Start()
    {
        //Hide Cursor
        Cursor.visible = false;

        //setting Animations
        anima = gameObject.GetComponent<Animator>();
        Stand = true;
        standRight = true;
        standUp = false;
        standDown = false;
        isFacingRight = true;

        //setting Stamina
        Stamina = 100;

    }



    private void LateUpdate()
    {
        //Inputing X and Y
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        



        //setting moving position
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);


        //Animation
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

        //Hide stamina bar when it is not used
        if(staminaBar.transform.localScale.x >= 1)
        {
            staminaBar.SetActive(false);
        }
        else
        {
            staminaBar.SetActive(true);
        }
        //Setting running speed

        if (Input.GetKey(KeyCode.LeftShift))
            {

            if (staminaBar.transform.localScale.x > 0)
                    movespeed = 5f;
                else
                    movespeed = 3f;
            }
            else
            {
                movespeed = 3f;
            }


        //Tracking stamina
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (staminaBar.transform.localScale.x >= 0)
            {
                if (Stamina >= 0)
                    Stamina -= .5f * Time.deltaTime;
                staminaBar.transform.localScale -= new Vector3(Stamina * .002f, 0, 0) * Time.deltaTime;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (staminaBar.transform.localScale.x < 1)
            {
                if (Stamina < 100)
                    Stamina += .5f * Time.deltaTime;
                staminaBar.transform.localScale += new Vector3(Stamina * .0015f, 0, 0) * Time.deltaTime;
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
