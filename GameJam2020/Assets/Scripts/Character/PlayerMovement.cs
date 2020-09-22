using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;


    public float runSpeed = 40f;
    public Joystick joystick;
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {


        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;

        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }


        if (joystick.Vertical >= .6f)
        {
            jump = true;
        }

        if (joystick.Vertical <= -.6f)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

