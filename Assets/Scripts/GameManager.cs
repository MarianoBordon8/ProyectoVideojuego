using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    private bool juegoTerminado = false;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    public void PerderJuego()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        Debug.Log("¡¡Perdiste!!");
        Invoke("ReiniciarNivel", 0f);
    }

    public void IntentarGanarJuego()
    {
        if (juegoTerminado) return;

        if (EnemyManager.instancia.enemigosVivos == 0)
        {
            juegoTerminado = true;
            Debug.Log("¡¡Ganaste!!");
            Invoke("CargarSiguienteNivel", 0f);

        }
        else
        {
            Debug.Log("¡No ganaste todavía! Aún quedan enemigos.");
        }
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void CargarSiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int totalEscenas = SceneManager.sceneCountInBuildSettings;

        if (escenaActual + 1 < totalEscenas)
        {
            SceneManager.LoadScene(escenaActual + 1);
        }
        else
        {
            Debug.Log("¡Ganaste el último nivel!");
            SceneManager.LoadScene(0);
        }
    }
}

