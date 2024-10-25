using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Función para cambiar a la escena de selección de rol
    public void IrASeleccionRol()
    {
        // Cambia a la escena llamada "SeleccionRol"
        SceneManager.LoadScene("SeleccionRol");

        Debug.Log("Iniciaste ahora selecciona tú rol");
    }

}