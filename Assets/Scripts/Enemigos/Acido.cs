using UnityEngine;

public class Acido : MonoBehaviour
{
    public int daño = 10;
    public float intervaloDaño = 2f;

    private VidaPersonaje vidaPersonaje;
    private bool estaEnElCharco = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            vidaPersonaje = other.GetComponent<VidaPersonaje>();

            if (vidaPersonaje != null)
            {
                vidaPersonaje.RecibirDaño(daño);
                estaEnElCharco = true;
                InvokeRepeating("DañarPersonaje", intervaloDaño, intervaloDaño);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnElCharco = false;
            CancelInvoke("DañarPersonaje");
            vidaPersonaje = null;
        }
    }

    void DañarPersonaje()
    {
        if (estaEnElCharco && vidaPersonaje != null)
        {
            vidaPersonaje.RecibirDaño(daño);
        }
    }
}
