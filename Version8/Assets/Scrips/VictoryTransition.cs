using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class VictoryTransition : MonoBehaviour
{
    void Update()
    {
        // Busca el objeto con el tag "Player"
        GameObject player = GameObject.FindWithTag("Player");

        // Si no existe un objeto con el tag "Player", significa que ha sido destruido
        if (player == null)
        {
            Debug.Log("El objeto con el tag 'Player' ha sido destruido, cambiando de escena...");
            ChangeToVictoriaScene();
        }
    }

    void ChangeToVictoriaScene()
    {
        Debug.Log("Cambiando a la escena de victoria...");
        SceneManager.LoadScene("Victoria");  // Cambia a la escena de victoria
    }
}