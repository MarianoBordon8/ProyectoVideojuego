using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.IntentarGanarJuego();
            }

        }
    }
}
