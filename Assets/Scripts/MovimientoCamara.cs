using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float sensibilidad = 100f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        rotacionY += Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        rotacionX -= Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        rotacionX = Mathf.Clamp(rotacionX, -80f, 80f);

        transform.rotation = Quaternion.Euler(0f, rotacionY, rotacionX);
    }
}