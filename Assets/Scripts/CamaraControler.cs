using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{

    public Transform target; // Objeto que designa la camara para que lo siga

    public float minHeight, maxHeight; //Con esto decimos la altura maxima y minimo que puede estar la camara

    // Empieza del inicio en la primera actualización
    void Start()
    {
        
    }

    // Se actualiza una vez por cuadro
    void Update()
    {
        // Se ponen tres puntos de posicion, porque trabajamos con un vector 3 y de esta manera movernos por el mapa y que nos siga la camara de manera horizontal y vertical
        // transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z)
        //Clamp nos deja trabajar con dos valores y, z.

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
    }
}