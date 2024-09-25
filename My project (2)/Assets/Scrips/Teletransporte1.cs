using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte1 : MonoBehaviour
{
    public Transform Target2;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = Target2.transform.position;
    }

  
    
       
    

}
