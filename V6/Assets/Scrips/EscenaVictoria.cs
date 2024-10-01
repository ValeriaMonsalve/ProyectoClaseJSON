using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaVictoria : MonoBehaviour
{
    [Header("Jugador B")]
    public GameObject player;

    void Update()
    {
        if (player.GetComponent<AlmacenDatos>().TareasCompletadas == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
