using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    CharacterController player;

    [Header("Opciones de Personaje")]

    public float walkSpeed = 2.5f;
    public float runSpeed = 7.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 move = Vector3.zero;

    [Header("Opciones de Camara")]
    
    public Camera cam;
    public float velHorizontal = 3.0f;
    public float velVertical = 2.0f;
    public float limitVerticalMax = 60.0f;
    public float limitVerticalMin = -65.0f;
    float horizontalMouse, verticalMouse;

    [Header("Opciones de Animaciones")]

    public Animator animator;

    void Start()
    {
        player = GetComponent<CharacterController>();    
    }

    
    void FixedUpdate()
    {
        horizontalMouse = velHorizontal * Input.GetAxis("Mouse X");
        verticalMouse += velVertical * Input.GetAxis("Mouse Y");
        
        verticalMouse = Mathf.Clamp(verticalMouse, limitVerticalMin, limitVerticalMax);
        cam.transform.localEulerAngles = new Vector3(-verticalMouse, 0.0f, 0.0f);
        transform.Rotate(0, horizontalMouse, 0);
        
        
        if (player.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
                animator.SetBool("Runing", true);
            } else
            {
                move = transform.TransformDirection(move) * walkSpeed;
                animator.SetBool("Runing", false);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }
        
        move.y -= gravity * Time.deltaTime;
        player.Move(move * Time.deltaTime);

        animator.SetFloat("velX", Input.GetAxis("Horizontal"));
        animator.SetFloat("velZ", Input.GetAxis("Vertical"));
    }   
}
