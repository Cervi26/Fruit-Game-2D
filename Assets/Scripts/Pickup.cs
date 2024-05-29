using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isApple;
    public bool isCherries;
    public bool isMelon;      // De esta manera definimos si nuetro pickup es de tipo fruta.
    
    public bool isHeal;

    private bool isCollected; // Hacemos un booleano.

    public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !isCollected) // Por si no ha sido recolectada.
        {
            if (isApple)
            {
                LevelManager.instance.appleCollected++; // Hacemos el conteo de las frutas.

                UIController.instance.UpdateAppleCount(); // Aqui llamamos a la instancia cada vez que cogemos una fruta.
                AudioManager.instance.PlaySFX(0);


                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject); // Destruimos la fruta una vez cogida.
            }

            if (isCherries)
            {
                LevelManager.instance.cherriesCollected++; // Hacemos el conteo de las frutas.

                UIController.instance.UpdateCherriesCount(); // Aqui llamamos a la instancia cada vez que cogemos una fruta.
                AudioManager.instance.PlaySFX(0);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject); // Destruimos la fruta una vez cogida.
            }

            if (isMelon)
            {
                LevelManager.instance.melonCollected++; // Hacemos el conteo de las frutas.

                UIController.instance.UpdateMelonCount(); // Aqui llamamos a la instancia cada vez que cogemos una fruta.
                AudioManager.instance.PlaySFX(0);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject); // Destruimos la fruta una vez cogida.
            }

            if (isHeal)
            {
                if (PlayerHealthControler.Instance.currentHealth != PlayerHealthControler.Instance.maxHealth)
                {
                    PlayerHealthControler.Instance.HealPlayer();
                    AudioManager.instance.PlaySFX(1);

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
