using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public bool activated = false;

    public static CheckPoint activeCheckpoint;

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;
            //Realiza aqu� las acciones que desees activar el checkpoint, como guardar la posici�n del jugador.

            activeCheckpoint = this;

            //Guarda la posici�n del juagdor en PlayerPrefs
            PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);

            //Luego, puedes guardar otros datos que desees, como �a puntuaci�n o el estado del juego.
            //PlayerPrefs.SetInt ("Score", 100);

            //Guarda los cambios en PlayerPrefs
            PlayerPrefs.Save();


            //Realiza aqu� las acciones que desees al activar el checkpoint.
        }

    }

}