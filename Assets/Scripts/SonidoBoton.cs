using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    public AudioSource audioBoton;       
    public string accion;

    private float temporizador = 0f;
    private bool esperando = false;
    private float demora = 2f;

    void Update()
    {
        if (!esperando) return;

        temporizador += Time.unscaledDeltaTime;

        if (temporizador >= demora)
        {
            EjecutarAccion();
            esperando = false;
            temporizador = 0f;
        }
    }

    public void EjecutarAccionConSonido()
    {
        

        

        
        
            if (audioBoton != null)
                audioBoton.Play();
        
        

        esperando = true;
        temporizador = 0f;
    }

    void EjecutarAccion()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        if (gm == null)
        {
            Debug.LogWarning("GameManager no encontrado.");
            return;
        }

        switch (accion)
        {
            case "menu": gm.IrAlMenu(); break;
            case "reiniciar": gm.ReintentarNivel(); break;
            case "salir": gm.SalirDelJuego(); break;
            case "siguiente": gm.SiguienteNivel(); break;
            case "tutorial": gm.IrATutorial(); break;
            default: Debug.LogWarning("Acción desconocida: " + accion); break;
        }
    }
}
