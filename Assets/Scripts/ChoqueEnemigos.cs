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
        if (collision.gameObject.tag == "Enemy")
        {
            if (vidaPersonaje != null)
            {
                vidaPersonaje.RecibirDaño(1); ;
            }
        }
    }
}
