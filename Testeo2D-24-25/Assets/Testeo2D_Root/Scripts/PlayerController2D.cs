using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    
    //Referencias generales
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player 
    [SerializeField] PlayerInput playerInput; //Ref al gestor del input del jugador
    [SerializeField] Animator playerAnim; //Ref al animator para gestionar las transiciones de animación
    [Header("Movement Parameters")]

    private Vector2 moveInput; //Almacén del input del player
    public float speed;
    [SerializeField] bool isFacingRight;

    [Header ("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;


    void Start()
    {
        //Autoreferenciarcomponentes: nombre de variable = GetComponent
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
      //flip
      if (moveInput.x > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
      if (moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
       playerRb.velocity = new Vector2(moveInput.x * speed, playerRb.velocity.y);
    }

   void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = !nombre de bool (cambio al estado contrario)
    }

    #region Input Events
    //Para crea un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al input (Callback.Context)

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }

    #endregion



}
