using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelManager : MonoBehaviour
{
    public static NivelManager instancia;
    public int nivelActual;

    void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EstablecerNivelActual(int nivel)
    {
        nivelActual = nivel;
    }

    public void AvanzarNivel()
    {
        nivelActual++;
    }

    public int ObtenerNivelActual()
    {
        return nivelActual;
    }
}
