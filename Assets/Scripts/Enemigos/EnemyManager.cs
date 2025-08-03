using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instancia; 
    public GameObject circuloVictoria;
    public Vector3 posicionVictoria = Vector3.zero;

    private bool victoriaGenerada = false;
    public int enemigosVivos = 0;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegistrarEnemigo()
    {
        enemigosVivos++;
        Debug.Log("Quedan: " + enemigosVivos + " Enemigos");
    }

    public void EliminarEnemigo()
    {
        enemigosVivos--;
        Debug.Log("Quedan: " + enemigosVivos + " Enemigos");

        if (enemigosVivos <= 0 && !victoriaGenerada)
        {
            victoriaGenerada = true;
            Debug.Log("¡Todos los enemigos han sido derrotados!");

            
            if (circuloVictoria != null)
            {
                Instantiate(circuloVictoria, posicionVictoria, Quaternion.identity);
                Debug.Log("¡Victoria generada en la cima!");
            }

            
            
        }
    }
}
