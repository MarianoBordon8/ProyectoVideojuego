using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vida;

    void Start()
    {
        EnemyManager.instancia?.RegistrarEnemigo();
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            EnemyManager.instancia?.EliminarEnemigo();
            Destroy(gameObject);
        }
    }
}
