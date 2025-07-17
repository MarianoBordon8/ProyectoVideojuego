using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlador : MonoBehaviour
{
    public void CargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void CargarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    public void CargarNivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }
}
