using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoPersonaje : MonoBehaviour
{
    public float speed;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
