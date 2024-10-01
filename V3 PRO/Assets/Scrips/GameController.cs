using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        if (PlayerRoleManager.Instance.playerRole == PlayerRoleManager.PlayerRole.Cazador)
        {
            // Código para iniciar al jugador como Cazador
            Debug.Log("Eres el Cazador");
        }
        else if (PlayerRoleManager.Instance.playerRole == PlayerRoleManager.PlayerRole.Impostor)
        {
            // Código para iniciar al jugador como Impostor
            Debug.Log("Eres el Impostor");
        }
    }
}