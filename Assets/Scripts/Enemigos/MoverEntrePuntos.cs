using UnityEngine;

public class MoverEntrePuntos : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;
    public float velocidadRotacion = 5f;

    private Transform objetivoActual;

    void Start()
    {
        objetivoActual = puntoB; // Empezamos yendo hacia B
    }

    void Update()
    {
        if (objetivoActual == null) return;

        // Dirección hacia el objetivo
        Vector3 direccion = (objetivoActual.position - transform.position).normalized;

        // Rotación suave hacia el objetivo
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }

        // Movimiento hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Al llegar, cambiar objetivo
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.2f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }
}
