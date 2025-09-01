using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia; // singleton
    public int nivelActual;
    public int nivelMaximo = 3;
    private bool juegoTerminado = false;

    void Awake()
    {
        // Si no hay instancia, esta será la única
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // mantiene el GameManager entre escenas
        }
        else
        {
            Destroy(gameObject); // destruye duplicados
        }
    }

    void Start()
    {
        string nombreEscena = SceneManager.GetActiveScene().name;
        if (nombreEscena.StartsWith("Nivel"))
        {
            if (int.TryParse(nombreEscena.Replace("Nivel", ""), out int numeroNivel))
            {
                NivelManager.instancia?.EstablecerNivelActual(numeroNivel);
            }
        }
    }

    public void PerderJuego()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        SceneManager.LoadScene("PerderNivel");
    }

    public void IntentarGanarJuego()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;

        int nivelActual = NivelManager.instancia.ObtenerNivelActual();

        if (nivelActual >= nivelMaximo)
        {
            SceneManager.LoadScene("GanarJuego");
        }
        else
        {
            SceneManager.LoadScene("GanarNivel");
        }
    }

    public void SiguienteNivel()
    {
        NivelManager.instancia.AvanzarNivel();
        int siguiente = NivelManager.instancia.ObtenerNivelActual();
        SceneManager.LoadScene("Nivel" + siguiente);
        juegoTerminado = false;
    }

    public void ReintentarNivel()
    {
        int nivelActual = NivelManager.instancia.ObtenerNivelActual();
        SceneManager.LoadScene("Nivel" + nivelActual);
        juegoTerminado = false;
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
        juegoTerminado = false;
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void IrATutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
