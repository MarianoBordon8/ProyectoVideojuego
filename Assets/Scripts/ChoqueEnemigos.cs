using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueEnemigos : MonoBehaviour
{
    private VidaPersonaje vidaPersonaje;

    void Start()
    {
        vidaPersonaje = GetComponent<VidaPersonaje>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Alto" || collision.gameObject.name == "Pequeño" || collision.gameObject.name == "Ancho")
        {
            if (vidaPersonaje != null)
            {
                vidaPersonaje.RestarVida();
            }
        }
    }
}
