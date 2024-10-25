using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportacion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger en la posición: " + transform.position);

            
            Debug.Log("Posición anterior del jugador: " + other.transform.position);

           
            other.transform.position = new Vector3(9.17f, 0.5f, 36.03f);

       
            Debug.Log("Jugador teletransportado a: " + other.transform.position);
        }
        else
        {
            Debug.Log("Objeto no es el jugador: " + other.name);
        }
    }
}