using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public SpriteRenderer theSR; //Se declara variables del sprite renderer del checkpoint

    public Sprite cpON, cpOFF; //Hay dos posibles checkpoints (encendido y apagado)

    //Cuando el player choca contra la bandera del checkpoint:
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Desactiva todos los checkpoints que hubiese activados
            checkPointController.instance.DeactivateCheckpoints(); ;

            theSR.sprite = cpON; //Pone la bandera en modo ON

            //Y guarda la posición del transform de la bandera, para después poder enviar al player justo a esa posición al reaparecer
            checkPointController.instance.SetSpawnPoint(transform.position);
        }
    }

    //Función que se encarga de resetear los checkpoints visualmente
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOFF;
    }
}
