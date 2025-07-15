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
            GameManager.instancia?.PerderJuego();
            
        }
    }

    
}
