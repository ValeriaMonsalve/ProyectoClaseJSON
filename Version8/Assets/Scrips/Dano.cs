using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Necesario para usar UI, como Slider

public class Dano : MonoBehaviour
{
    public int vida = 100;  // Vida máxima del jugador
    public Slider barraVida;  // Referencia al Slider de la barra de vida

    void Start()
    {
        // Verifica si el Slider está asignado correctamente
        if (barraVida != null)
        {
            barraVida.maxValue = vida;  // Configura el valor máximo del slider
            barraVida.value = vida;  // Inicializa el slider con la vida inicial
        }
        else
        {
            Debug.LogError("No se ha asignado la barra de vida en el Inspector.");
        }
    }

    // Método para restar vida al jugador
    public void RestarVida(int cantidad)
    {
        print("RestarVida");
        vida -= cantidad;  // Resta vida
        if (vida < 0) vida = 0;  // Asegurarse de que la vida no sea negativa

        // Actualizar el valor del Slider si está asignado
        if (barraVida != null)
        {
            barraVida.value = vida;
        }
        else
        {
            Debug.LogError("No se ha asignado la barra de vida.");
        }

        print("Vida restante: " + vida);

        // Verificar si la vida llega a 0 y el jugador muere
        if (vida <= 0)
        {
            Muerte();
        }
    }

    // Método que se llama cuando la vida llega a 0
    void Muerte()
    {
        print("El jugador ha muerto.");
        gameObject.SetActive(false);  // Desactiva el GameObject para "desaparecer" el jugador
    }

    // Detectar colisión con la bala
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))  // Verificar si el objeto es una bala
        {
            print("El jugador fue golpeado por una bala.");
            RestarVida(10);  // Restar 10 puntos de vida (o la cantidad que desees)
        }
    }
}