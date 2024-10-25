using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Movimiento, Rotación, Reacción y Salto")]
    public float veloMovimiento;
    public float veloRotacion;
    public float tiempoReaccion;
    public float fuerzaSalto;

    private int movimiento;
    private bool espera, camina, gira, puedeSaltar;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        accion();
        puedeSaltar = true;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, 2.5f))
        {
            if(hit.collider)
            {
                gira = true; 
                StartCoroutine(tiempoGiro());
            }
        }

        if (camina)
        {
            transform.position += (transform.forward * veloMovimiento * Time.deltaTime);
        }

        if (gira)
        {
            transform.Rotate(Vector3.up * veloRotacion * Time.deltaTime);
        }


        if (puedeSaltar && movimiento == 4)
        {
            Salto();
        }
    }

    void accion()
    {
        movimiento = Random.Range(1, 5);

        if (movimiento == 1)
        {
            camina = true;
            espera = false;
        }

        if (movimiento == 2)
        {
            espera = true;
            camina = false;
        }

        if (movimiento == 3)
        {
            gira = true;
            StartCoroutine(tiempoGiro());
        }

        if (movimiento == 4)
        {
            puedeSaltar = true;
        }

        Invoke("accion", tiempoReaccion);
    }

    void Salto()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        puedeSaltar = false;
    }

    IEnumerator tiempoGiro()
    {
        yield return new WaitForSeconds(2);
        gira = false;
    }
}
