using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    public Transform Target;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = Target.transform.position;
    }

  
    
       
    

}
