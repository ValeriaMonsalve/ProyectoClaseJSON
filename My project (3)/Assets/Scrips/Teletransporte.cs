using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger");

            // Imprime la posición actual del jugador
            Debug.Log("Posición anterior del jugador: " + other.transform.position);

            // Teletransporta al jugador a la nueva posición
            other.transform.position = new Vector3(9.17f, 0.5f, 36.03f);

            // Imprime la nueva posición del jugador
            Debug.Log("Jugador teletransportado a: " + other.transform.position);
        }
        else
        {
            Debug.Log("Objeto no es el jugador: " + other.name);
        }
    }
}