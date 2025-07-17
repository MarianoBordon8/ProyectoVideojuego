using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject balaPrincipal;
    public GameObject balaSecundaria;
    public float velocidadBala;
    public Transform puntoDisparo;

    public int cargadorPrincipal = 10;
    public int cargadorSecundario = 5;

    private int balasRestantesPrincipal;
    private int balasRestantesSecundario;

    void Start()
    {
        balasRestantesPrincipal = cargadorPrincipal;
        balasRestantesSecundario = cargadorSecundario;

        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("DispararProyectilPrincipal", 0, 2f);
        }
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (balasRestantesPrincipal > 0)
                {
                    DispararProyectil(balaPrincipal);
                    balasRestantesPrincipal--;
                    Debug.Log("Bala principal restante: " + balasRestantesPrincipal);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (balasRestantesSecundario > 0)
                {
                    DispararProyectil(balaSecundaria);
                    balasRestantesSecundario--;
                    Debug.Log("Bala secundaria restante: " + balasRestantesSecundario);
                }
            }
        }
    }

    void DispararProyectilPrincipal()
    {
        if (balasRestantesPrincipal > 0)
        {
            DispararProyectil(balaPrincipal);
            balasRestantesPrincipal--;
        }
    }

    void DispararProyectil(GameObject balaPrefab)
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

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
