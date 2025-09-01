using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vida;
    public AudioClip sonidoDaño;
    private AudioSource audioSource;

    void Start()
    {
        EnemyManager.instancia?.RegistrarEnemigo();
        audioSource = GetComponent<AudioSource>();
    }

    public void RecibirDaño(int daño)
    {
        audioSource.PlayOneShot(sonidoDaño);
        vida -= daño;
        
        if (vida <= 0)
        {
            EnemyManager.instancia?.EliminarEnemigo();
            Destroy(gameObject);
        }
    }
}
