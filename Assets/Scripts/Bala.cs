using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int daño;
    [HideInInspector] public GameObject origenDisparo;

    void OnTriggerEnter(Collider collision)
    {
        if (origenDisparo == null)
        {
            return;
        }

        if (collision.gameObject == origenDisparo)
        {
            return;
        }

        if (origenDisparo.CompareTag("Player"))
        {
            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            if (enemigo != null)
            {
                enemigo.RecibirDaño(daño);
            }
        }

        if (origenDisparo.CompareTag("Enemy"))
        {
            VidaPersonaje jugador = collision.gameObject.GetComponent<VidaPersonaje>();
            if (jugador != null)
            {
                jugador.RecibirDaño(daño);
            }
        }

        Destroy(gameObject);
    }
}
