using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public int value = 1; //Valor del objeto que será recolectado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Aseguramos que el player tenga el tag Player
        {
            Debug.Log("Soy el player y estoy en el trigger de la banana");

            GameManager.instance.CollectableItem(value); // Llamado a la función de GameManager
            Destroy (gameObject);//El objeto fue destruido

            Debug.Log("La banana fue destruida");
        }
    }
}
