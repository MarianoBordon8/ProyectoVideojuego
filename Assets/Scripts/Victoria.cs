using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    public AudioClip sonidoVictoria;
    private AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        audioSource = GetComponent<AudioSource>();
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sonidoVictoria);

            Invoke("EjecutarVictoria", 4f);

        }
    }
    void EjecutarVictoria()
    {
        if (GameManager.instancia != null)
        {
            GameManager.instancia.IntentarGanarJuego();
        }
        else
        {
            Debug.LogError("GameManager no encontrado!");
        }
    }
}
