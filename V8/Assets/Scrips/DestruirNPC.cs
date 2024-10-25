using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirNPC : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Bala"))
        {
          
            Destroy(gameObject);

        }
    }
}
