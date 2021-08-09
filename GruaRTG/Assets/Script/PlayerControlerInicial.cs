using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerInicial : MonoBehaviour
{
    [Header("Opciones de Animaciones")]

    public Animator animator;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Runing", true);
        }
        else
        {
            animator.SetBool("Runing", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        animator.SetFloat("velX", Input.GetAxis("Horizontal"));
        animator.SetFloat("velZ", Input.GetAxis("Vertical"));
        animator.SetBool("Escalera", false);
    }
}