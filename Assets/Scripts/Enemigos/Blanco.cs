using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    private ControladorBlancos controlador;

    void Start()
    {
        controlador = FindObjectOfType<ControladorBlancos>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Bala"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (controlador != null)
                controlador.BlancoDestruido();
        }
    }
}
