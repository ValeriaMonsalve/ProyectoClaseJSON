using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AlmacenDatos : MonoBehaviour

{
    [Header("Tareas")]
    public int Tarea1;
    public int Tarea2;
    public int Tarea3;
    public bool TareasCompletadas = false;

    [Header("Texto Tareas")]
    public TextMeshProUGUI textoMision;


    void Update()
    {
        if (Tarea1 < 3)
        {
            textoMision.text = "Recolectar 3 órdenes de los clientes" +
                               "\n Llevas: " + Tarea1;
        }
        else if (Tarea2 < 3)
        {
            textoMision.text = "Cambiar las etiquetas de los ingredientes" +
                               "\n en la zona de producto " + Tarea2 + "/3";
        }
        else if (Tarea3 < 1)
        {
            textoMision.text = "Lleva un plato desde la cocina " +
                               "\n hasta la zona de comida para un crítico culinario";
        }
        else
        {
            textoMision.text = "Ha ganado el jugador B";
            TareasCompletadas= true;
        }
    }
}
