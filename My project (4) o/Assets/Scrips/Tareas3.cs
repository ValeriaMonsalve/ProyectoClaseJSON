using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tareas3 : MonoBehaviour
{
    [Header("Tomar y Recoger el objeto")]
    public GameObject cubo;
    public Transform mano;

    [Header("Detectar zona")]
    public Transform lugarSuelto; 
    public bool activo;
    public bool enLugarCorrecto;

    [Header("Jugador B")]
    public GameObject jugador;

    void Update()
    {
        if (activo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cubo.transform.SetParent(mano);
                cubo.transform.position = mano.position;
                cubo.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;

            if (enLugarCorrecto)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    jugador.GetComponent<AlmacenDatos>().Tarea3 += 1;
                    enLugarCorrecto = false; 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = true;
        }

        if (other.tag == "Tarea3")
        {
            enLugarCorrecto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = false;
        }

        if (other.tag == "Tarea3")
        {
            enLugarCorrecto = false;
        }
    }

}

