using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CaminoDesaparecedor : MonoBehaviour
{
    public GameObject[] seccionesPiso;
    public float tiempoEntreDesapariciones = 3f;

    public Text textoCorre;
    public Text textoTemporizador;

    private int indiceActual = 0;
    private float temporizador = 0f;
    private bool comenzarDesaparicion = false;

    void Start()
    {
        if (textoCorre != null) textoCorre.gameObject.SetActive(false);
        if (textoTemporizador != null) textoTemporizador.gameObject.SetActive(false);
    }

    void Update()
    {
        if (comenzarDesaparicion && indiceActual < seccionesPiso.Length)
        {
            temporizador += Time.deltaTime;
            float tiempoRestante = Mathf.Ceil(tiempoEntreDesapariciones - temporizador);

            if (textoTemporizador != null)
                textoTemporizador.text = tiempoRestante.ToString();

            if (temporizador >= tiempoEntreDesapariciones)
            {
                if (seccionesPiso[indiceActual] != null)
                    seccionesPiso[indiceActual].SetActive(false);

                indiceActual++;
                temporizador = 0f;

                if (indiceActual >= seccionesPiso.Length)
                {
                    if (textoCorre != null) textoCorre.gameObject.SetActive(false);
                    if (textoTemporizador != null) textoTemporizador.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !comenzarDesaparicion)
        {
            comenzarDesaparicion = true;
            temporizador = 0f;

            if (textoCorre != null) textoCorre.gameObject.SetActive(true);
            if (textoTemporizador != null)
            {
                textoTemporizador.gameObject.SetActive(true);
                textoTemporizador.text = tiempoEntreDesapariciones.ToString();
            }

            Debug.Log("¡COOORRRREEEEE!");
        }
    }
}
