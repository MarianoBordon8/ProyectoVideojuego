using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPersonaje : MonoBehaviour
{
    public int vidas;

    public void RestarVida()
    {
        vidas--;
        print("te quedan " + vidas + " vidas");

        if (vidas == 0)
        {
            Destroy(gameObject);
        }
    }
}
