using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointController : MonoBehaviour
{
    public static checkPointController instance; //Instancia para usarlo en otros scripts

    public checkPoint[] checkpoints; //Declara una matriz para asignar los checkpoints que tenga el nivel

    public Vector3 spawnPoint; //Se declara un vector para guardar una posicion

    void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        //Busca los objetos de tipo checkpoint
        checkpoints = FindObjectsOfType<checkPoint>();

        //Le da a esta variable, el valor de la posición de ese transform del player controller
        spawnPoint = PlayerController.instance.transform.position;
    }


    //Esta función de encarga de ir uno a uno cada checkpoint, desactivandolo con la función que se hizo en "checkPoint.cs"
    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    //Crea un nuevo spawn point con el valor del antiguo
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
