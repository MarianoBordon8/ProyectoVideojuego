using UnityEngine;

public class MovimientoEnemigoIdaVuelta : MonoBehaviour
{
    public Transform[] puntos;           // Lista de puntos a recorrer
    public float velocidad = 3f;         // Velocidad de movimiento
    public float velocidadRotacion = 5f; // Qué tan rápido rota hacia el objetivo

    private int indiceActual = 0;
    private int direccion = 1; // 1 para adelante, -1 para atrás

    void Update()
    {
        if (puntos.Length < 2) return; // Necesitamos al menos dos puntos

        Transform objetivo = puntos[indiceActual];

        // Calcular dirección hacia el objetivo
        Vector3 direccionMovimiento = (objetivo.position - transform.position).normalized;

        // Rotar suavemente hacia el objetivo
        if (direccionMovimiento != Vector3.zero)
        {
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccionMovimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
        }

        // Mover hacia el punto objetivo
        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

        // Si llegó al punto objetivo
        if (Vector3.Distance(transform.position, objetivo.position) < 0.2f)
        {
            indiceActual += direccion;

            // Cambiar de dirección al llegar a un extremo
            if (indiceActual >= puntos.Length)
            {
                indiceActual = puntos.Length - 2;
                direccion = -1;
            }
            else if (indiceActual < 0)
            {
                indiceActual = 1;
                direccion = 1;
            }
        }
    }
}
