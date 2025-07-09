using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadBala;
    public Transform puntoDisparo;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("DispararProyectil", 0f);
        }
    }

    void DispararProyectil()
    {
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDisparo.forward * velocidadBala;
        }
        Destroy(bala, 6f);

    }
}
