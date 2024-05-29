using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public SpriteRenderer theSR;

    public Sprite cpON, cpOFF;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointController.instance.DeactivateCheckpoints(); ;

            theSR.sprite = cpON;

            checkPointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        theSR.sprite = cpOFF;
    }
}
