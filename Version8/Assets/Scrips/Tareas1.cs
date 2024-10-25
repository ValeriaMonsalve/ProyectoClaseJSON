using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tareas1 : MonoBehaviour
{
    [Header("Jugador B")]
    public GameObject player;

    void OnTriggerEnter(Collider other)

    {
        player.GetComponent<AlmacenDatos>().Tarea1 += 1;
        Destroy(this.gameObject);

    }
    
}
