using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    public float lifeTime; //Declaramos una variable de tipo float, que se encarga de asignar un tiempo de vida a los objetos de efectos de collect y death

    // Update is called once per frame
    void Update()
    {
        //Destruye el objeto después de que pase el tiempo que se asigne en Unity
        Destroy(gameObject, lifeTime);
    }
}
