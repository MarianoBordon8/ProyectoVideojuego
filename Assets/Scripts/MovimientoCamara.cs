using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    Transform camaraT;

    float movX;
    float movY;

    void Start()
    {
        camaraT = Camera.main.transform;
    }

    void Update()
    {
        if (camaraT == null) Debug.Log("sssssssssssssssssssssssssssssss");
        movX -= Input.GetAxis("Mouse Y");
        movY += Input.GetAxis("Mouse X");

        movX = Mathf.Clamp(movX, -40, 30);

        camaraT.eulerAngles = new Vector3(movX, camaraT.eulerAngles.y, camaraT.eulerAngles.z);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, movY, transform.eulerAngles.z);
    }
}