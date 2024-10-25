using UnityEngine;
using UnityEngine.SceneManagement;

public class RoleSelection : MonoBehaviour
{
    // Este método será llamado cuando se elija el Cazador
    public void SelectCazador()
    {
        PlayerRoleManager.Instance.SetPlayerRole("Cazador");
        SceneManager.LoadScene("Partida"); // Cambia a la escena de la partida
    }

    // Este método será llamado cuando se elija el Impostor
    public void SelectImpostor()
    {
        PlayerRoleManager.Instance.SetPlayerRole("Impostor");
        SceneManager.LoadScene("Partida"); // Cambia a la escena de la partida
    }
}