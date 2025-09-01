using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


public class VidaPersonaje : MonoBehaviour
{
    public int vidas;
    public AudioClip sonidoDaño;
    private AudioSource audioSource;

    public void RecibirDaño(int daño)
    {
        audioSource.PlayOneShot(sonidoDaño);
        vidas -= daño;
        print("te quedan " + vidas + " vidas");

        if (vidas <= 0)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.PerderJuego();
            }
            else
            {
                Debug.LogWarning("GameManager no encontrado en la escena.");
            }


        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



}
