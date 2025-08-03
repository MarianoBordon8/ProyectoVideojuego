using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VidaPersonaje : MonoBehaviour
{
    public int vidas;

    public void RecibirDaño(int daño)
    {
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

    
}
