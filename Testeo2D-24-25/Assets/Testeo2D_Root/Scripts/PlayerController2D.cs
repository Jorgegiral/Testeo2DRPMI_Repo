using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Referencia a las antiguas inputs
    float horInput;
    float verInput;

    //Referencias generales
    [SerializeField] Rigidbody2D playerRb; //Ref al rigibody del player

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;

    void Start()
    {
        //Autoreferenciar componentes: nombre de variable = GetComponent()
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector2(horInput * speed, playerRb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
