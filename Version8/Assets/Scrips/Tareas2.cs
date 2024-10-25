using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tareas2 : MonoBehaviour
{
    [Header("Nombre Etiqueta")]
    public string nuevoNombre = "Ingrediente Viejo";

    [Header("Ingrediente")]
    public GameObject ingredienteEnZona;

    [Header("Jugador B")]
    public GameObject jugador;
    public bool tareaRealizada = false;
    public bool jugadorEnZona = false; 

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && ingredienteEnZona != null && jugadorEnZona)
        {
            CambiarNombre();

            if (!tareaRealizada)
            {
                jugador.GetComponent<AlmacenDatos>().Tarea2 += 1;
                tareaRealizada = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject == jugador)
        {
            jugadorEnZona = true;
        }

        
        if (other.CompareTag("Tarea2"))
        {
            ingredienteEnZona = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject == jugador)
        {
            jugadorEnZona = false;
        }

        
        if (other.CompareTag("Tarea2"))
        {
            ingredienteEnZona = null;
            tareaRealizada = false;
        }
    }

    void CambiarNombre()
    {
        if (ingredienteEnZona != null)
        {
            ingredienteEnZona.name = nuevoNombre;
            TextMesh textMesh = ingredienteEnZona.GetComponentInChildren<TextMesh>();

            if (textMesh != null)
            {
                textMesh.text = nuevoNombre;
            }
        }
    }
}
