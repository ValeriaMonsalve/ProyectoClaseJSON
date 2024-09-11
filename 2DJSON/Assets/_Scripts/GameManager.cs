using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Contador Items")]
    public static GameManager instance; //Singleton del GameManager
    public TMP_Text itemCountText; //Referencia de la cantidad de items recolectados en texto;

    public int itemCount = 0; //contador de items recolectados

    void Awake()
    {
        instance = this;
    }

    public void CollectableItem (int value)
    {
        itemCount += value;
        UpdateItemCountText();
    }

    void UpdateItemCountText()
    {
        itemCountText.text = " : " + itemCount.ToString();
    }

}
