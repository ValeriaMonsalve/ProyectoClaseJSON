using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Gereneración de la Bala")]
    public GameObject bala;
    public Transform spawnPoint;

    [Header("Velocidad de la Bala")]
    public float fuerzaDisparo;
    public float shotRate;
    private float tiempoDisparo = 0;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))

        {
            if (Time.time > tiempoDisparo)
            {
                GameObject newBullet;

                newBullet = Instantiate(bala,spawnPoint.position,spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDisparo);

                tiempoDisparo = Time.time + shotRate;

                Destroy(newBullet,2);

            }
        }
    }
}
