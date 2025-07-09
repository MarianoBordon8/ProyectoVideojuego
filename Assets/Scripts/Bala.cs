using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int daño;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {


            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();

            if (enemigo != null)
            {
                enemigo.RecibirDaño(daño);
            }

            Destroy(gameObject);
        }
    }
}
