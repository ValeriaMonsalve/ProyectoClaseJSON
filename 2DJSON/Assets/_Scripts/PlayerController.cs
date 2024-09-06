using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Velocidad y salto")]
    public float velMovement = 5f; // Velocidad de movimiento
    public float fuerzaJump = 7f;  // Velocidad de salto

    private bool enElSuelo = false;

    [Header("RigidBody y Animator")]
    private Rigidbody2D rb;        //RigidBody Físicas 2D
    private Animator animator;  //Animatot Animaciones del player

    [Header("Movimiento Player")]
    public float movimientoH;      //Fuerza de movimiento en eje X a través de un Input

    [Header("Posicion del player")]
    public Transform playerTransform; //Posición, Escala y Rotación del Player


    void Start()
    {
        //Inicialización de Componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        //Debug de los componentes

        if (rb == null)
        {
            Debug.Log("No se encontró el componente RigidBody2D" + gameObject.name);
        }

        if (animator == null)
        {
            Debug.Log("No se encontró el componente Animator en el objeto" + gameObject.name);
        }
    }


    void Update()
    {
        //Movimiento Horizontal del Player
        movimientoH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));
        

        //Flip
        if (movimientoH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  //Movimiento hacia la derecha
        }
        else if (movimientoH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Movimiento hacia la izquierda 
        }

        //Salto
        if (Input.GetButton("Jump") && enElSuelo)
        {
            animator.SetBool ("Jump", true);
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detectar el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
            Debug.Log("Estoy tocando el suelo");
        }
    }

}
