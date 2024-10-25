using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public int vidaPlayer;
    

    private void Update()
    {

        if (vidaPlayer <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}