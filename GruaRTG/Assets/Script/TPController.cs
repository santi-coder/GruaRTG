using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPController : MonoBehaviour
{
    public CharacterController personaje;

    [Header("Variables movimiento")]

    public float speed = 0.0f;
    public float runSpeed = 0.0f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVeelocity;
    private float targetAngle;
    public Transform cam;

    Vector3 direccion; 

    void Start()
    {
        personaje = GetComponent<CharacterController>();    
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 6.0f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direccion = new Vector3(horizontal, 0.0f, vertical).normalized;

      
        if (direccion.magnitude >= 0.1f)
        {
            
            targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVeelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            personaje.Move(moveDir.normalized * speed * Time.deltaTime);
        }   
        
    }
}
