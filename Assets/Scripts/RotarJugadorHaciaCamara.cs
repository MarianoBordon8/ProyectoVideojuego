using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarJugadorHaciaCamara : MonoBehaviour
{
    public Transform camara;

    void Update()
    {
        Vector3 direccion = camara.forward;
        direccion.y = 0f;
        direccion.Normalize();

        if (direccion != Vector3.zero)
        {
            transform.forward = direccion;
        }
    }
}
