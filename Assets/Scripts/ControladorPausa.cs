using UnityEngine;

public class ControladorPausa : MonoBehaviour
{
    public RectTransform botonIzquierdo;
    public RectTransform botonDerecho;

    private Vector2 posOriginalIzquierda;
    private Vector2 posOriginalDerecha;

    // Posiciones fuera de pantalla (ajustar según resolución y canvas)
    private Vector2 posFueraPantallaIzquierda = new Vector2(-1000f, 0f);
    private Vector2 posFueraPantallaDerecha = new Vector2(1000f, 0f);

    private bool enPausa = false;

    void Start()
    {
        if (botonIzquierdo != null)
            posOriginalIzquierda = botonIzquierdo.anchoredPosition;

        if (botonDerecho != null)
            posOriginalDerecha = botonDerecho.anchoredPosition;

        // Al iniciar, ocultar los botones moviéndolos fuera de pantalla
        if (botonIzquierdo != null)
            botonIzquierdo.anchoredPosition = posFueraPantallaIzquierda;

        if (botonDerecho != null)
            botonDerecho.anchoredPosition = posFueraPantallaDerecha;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (enPausa)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    void PausarJuego()
    {
        if (botonIzquierdo != null)
            botonIzquierdo.anchoredPosition = posOriginalIzquierda;

        if (botonDerecho != null)
            botonDerecho.anchoredPosition = posOriginalDerecha;

        Time.timeScale = 0f;
        enPausa = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ReanudarJuego()
    {
        if (botonIzquierdo != null)
            botonIzquierdo.anchoredPosition = posFueraPantallaIzquierda;

        if (botonDerecho != null)
            botonDerecho.anchoredPosition = posFueraPantallaDerecha;

        Time.timeScale = 1f;
        enPausa = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}