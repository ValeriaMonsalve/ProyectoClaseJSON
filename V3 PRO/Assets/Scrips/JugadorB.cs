using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorB : MonoBehaviour
{
    private CharacterController jugador;

    [Header("Movimiento")]
    public float velocidadMovimiento;
    public float gravedad;
    public float fuerzaSalto;
    public float velocidadCaidaAcelerada;

    [Header("Cámara")]
    public Camera camaraJugador;  // Nueva variable para la cámara del jugador
    public float sensibilidadMouse;
    public float limiteRotacionVertical;

    [Header("Jugador Configuración")]
    public string ejeHorizontal = "Horizontal2";
    public string ejeVertical = "Vertical2";
    public string botonSalto = "Jump2";
    public string ejeMouseX = "Mouse X";
    public string ejeMouseY = "Mouse Y";

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
        float mouseX = Input.GetAxis(ejeMouseX) * sensibilidadMouse;
        transform.Rotate(0, mouseX, 0);

        float mouseY = Input.GetAxis(ejeMouseY) * sensibilidadMouse;
        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteRotacionVertical, limiteRotacionVertical);

        if (camaraJugador != null)
        {
            camaraJugador.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);
        }
    }

    void MoverJugador()
    {
        float horizontal = Input.GetAxis(ejeHorizontal);
        float vertical = Input.GetAxis(ejeVertical);
        Vector3 direccion = new Vector3(horizontal, 0, vertical);

        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }

        direccion = transform.TransformDirection(direccion);

        if (jugador.isGrounded)
        {
            velocidadVertical = -gravedad * Time.deltaTime;

            if (Input.GetButtonDown(botonSalto))
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
