using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgresoJugadorB : MonoBehaviour
{
    [Header("Texto Progreso Tareas")]
    public TextMeshProUGUI textoProgreso;
    public AlmacenDatos jugadorADatos;
 
    void Update()
    {
        int tareasCompletadas = 0;
        if (jugadorADatos.Tarea1 >= 3) tareasCompletadas++;
        if (jugadorADatos.Tarea2 >= 3) tareasCompletadas++;
        if (jugadorADatos.Tarea3 >= 1) tareasCompletadas++;

        textoProgreso.text = "Tareas completadas " + tareasCompletadas + "/3";
    }
}
