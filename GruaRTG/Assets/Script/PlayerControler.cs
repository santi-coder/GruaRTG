using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    CharacterController player;

    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 move = Vector3.zero;
    

    void Start()
    {
        player = GetComponent<CharacterController>();    
    }

    
    void FixedUpdate()
    {
        Debug.Log(player.isGrounded);
        if (player.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;   
            }
        }
        
        move.y -= gravity * Time.deltaTime;
        player.Move(move * Time.deltaTime);
    }
}