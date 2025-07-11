using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparenciaPared : MonoBehaviour
{
    public Transform jugador;
    public LayerMask layerParedes;

    private Material materialOriginal;
    private Renderer paredActual;

    void Update()
    {
        RaycastHit hit;
        Vector3 direccion = jugador.position - transform.position;

        if (Physics.Raycast(transform.position, direccion, out hit, direccion.magnitude, layerParedes))
        {
            Renderer rend = hit.collider.GetComponent<Renderer>();

            if (rend != null && rend != paredActual)
            {
                RestaurarPared();

                paredActual = rend;
                materialOriginal = rend.material;
                Material transparente = new Material(Shader.Find("Transparent/Diffuse"));
                transparente.color = new Color(materialOriginal.color.r, materialOriginal.color.g, materialOriginal.color.b, 0.3f);
                rend.material = transparente;
            }
        }
        else
        {
            RestaurarPared();
        }
    }

    void RestaurarPared()
    {
        if (paredActual != null)
        {
            paredActual.material = materialOriginal;
            paredActual = null;
        }
    }
}
