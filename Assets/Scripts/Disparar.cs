using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadBala;
    public Transform puntoDisparo;

    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("DispararProyectil", 0, 2f);
        }
    }
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("DispararProyectil", 0f);
            }
        }
        
        
    }

    void DispararProyectil()
    {

        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);

        Bala scriptBala = bala.GetComponent<Bala>();
        if (scriptBala != null)
        {
            scriptBala.origenDisparo = this.gameObject;
        }

        Collider balaCol = bala.GetComponent<Collider>();
        Collider emisorCol = GetComponent<Collider>();
        if (balaCol != null && emisorCol != null)
        {
            Physics.IgnoreCollision(balaCol, emisorCol);
        }

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDisparo.forward * velocidadBala;
        }

        Destroy(bala, 5f);
    }

    
}
