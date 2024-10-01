using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ControllerDataGame : MonoBehaviour
{
    //Referencia del player
    public GameObject player;

    //String para guardar y leer
    public string saveFile;

    //crearemos un objeto del tipo de los datos del jugador
    public DataGame dataGame= new DataGame();

    //crearemos un método awake para ejecutar antes de empezar el juego
    private void Awake()
    {
        //los archivos se guardan en la ubicación donde está el proyecto
        saveFile = Application.dataPath + "/datosJuego.json";
        //Este achivo JSON lo creamos para guardar variables 

        //buscamos el player en la escena
        player = GameObject.FindGameObjectWithTag ("Player");

        LoadData();     
    }

   
    //crearemos dos funciones para procesos de carga y guardado

     private void LoadData()

    {

        //Preguntar si el archivo existe
        if (File.Exists(saveFile))

        {
            //si existe ponemos el contenido en variable
            string dataContent = File.ReadAllText(saveFile);
            //obtenemos los datos de archivo json y se convierte en archivo entendible por Unity

            dataGame = JsonUtility.FromJson<DataGame>(dataContent);

            Debug.Log("Position Player:" + dataGame.Position);
        }
        else
        {
            Debug.Log("El archivo no existe");
        }

        //cambie de posición por la de archivo
        player.transform.position = dataGame.Position;

    }

    private void SaveData() 
    
    {
        //llamar la posición del juador al momento de guardar
        DataGame newData = new DataGame()
        {
            //agarrar los datos nuevos
            Position = player.transform.position
        };

        //lo volvemos  JSON
        string stringJson = JsonUtility.ToJson(newData);

        //Escribir datos
        File.WriteAllText(saveFile, stringJson);
    }

    private void Update()
  {
    if (Input.GetKeyDown (KeyCode.L)) 
    {
        LoadData();
    }
    if (Input.GetKeyDown (KeyCode.S))
    {
      SaveData();
    }
  }
}
