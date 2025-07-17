using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBlancos : MonoBehaviour
{
    // Lista o array para asignar todos los blancos en el editor
    public GameObject[] blancos;

    public GameObject pisoParaActivar;

    private int blancosRestantes;

    void Start()
    {
        blancosRestantes = blancos.Length;

        if (pisoParaActivar != null)
            pisoParaActivar.SetActive(false);
    }

    public void BlancoDestruido()
    {
        blancosRestantes--;

        if (blancosRestantes <= 0 && pisoParaActivar != null)
        {
            pisoParaActivar.SetActive(true);
        }
    }
}
