using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController jugador;

    [Header("Movimiento")]
    public float velocidadMovimiento;
    public float gravedad;
    public float fuerzaSalto;
    public float velocidadCaidaAcelerada;

    [Header("Cámara")]
    public float sensibilidadMouse;
    public float limiteRotacionVertical;

    private Vector3 movimiento;
    private float rotacionVertical = 0.0f;
    private float velocidadVertical = 0.0f;

    void Awake()
    {
        jugador = GetComponent<CharacterController>();
    }

    void Update()
    {
        RotarJugadorYCamara();
        MoverJugador();
    }

    void RotarJugadorYCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        transform.Rotate(0, mouseX, 0);
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteRotacionVertical, limiteRotacionVertical);

        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);
    }

    void MoverJugador()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0, vertical);

        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }

        direccion = transform.TransformDirection(direccion);

        if (jugador.isGrounded)
        {
            velocidadVertical = -gravedad * Time.deltaTime; 

            if (Input.GetButtonDown("Jump"))
            {
                velocidadVertical = fuerzaSalto;
            }
        }
        else
        {
            velocidadVertical -= (gravedad * velocidadCaidaAcelerada) * Time.deltaTime;
        }

        movimiento = direccion * velocidadMovimiento;
        movimiento.y = velocidadVertical;
        jugador.Move(movimiento * Time.deltaTime);
    }
}

