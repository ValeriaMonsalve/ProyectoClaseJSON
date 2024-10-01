using UnityEngine;

public class PlayerRoleManager : MonoBehaviour
{
    public static PlayerRoleManager Instance;

    public enum PlayerRole { Cazador, Impostor }

    public PlayerRole playerRole; // Aquí se guarda el rol del jugador

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerRole(string role)
    {
        if (role == "Cazador")
        {
            playerRole = PlayerRole.Cazador;
        }
        else if (role == "Impostor")
        {
            playerRole = PlayerRole.Impostor;
        }
    }
}
