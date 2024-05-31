using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // De esta manera definimos de que tipo es nuetro pikup
    public bool isApple;
    public bool isCherries;
    public bool isMelon;     
    public bool isHeal;

    private bool isCollected; // Hacemos un booleano para saber si está o no recolectado

    public GameObject pickupEffect; //Se usa para el efecto de recoger items por el mapa


    //Se ejecuta cuando el player, choca contra este objeto con trigger
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !isCollected) // Verifica que sea el player y que no ha sido recolectada.
        {
            if (isApple) //Si es manzana
            {
                LevelManager.instance.appleCollected++; // Hacemos el conteo de manzanas

                UIController.instance.UpdateAppleCount(); // Aqui actualizamos el contador de las manzanas
                AudioManager.instance.PlaySFX(0); //Se pone el efecto de sonido de recoger items


                Instantiate(pickupEffect, transform.position, transform.rotation); //Se indica en que position saldrá el efecto de recoger items

                isCollected = true; //Se pone como recogida la fruta
                Destroy(gameObject); // Destruimos la fruta una vez cogida.
            }

            //Funciona de la misma manera en cada fruta. (Cada una tiene su propio contador)
            if (isCherries)
            {
                LevelManager.instance.cherriesCollected++; 

                UIController.instance.UpdateCherriesCount();
                AudioManager.instance.PlaySFX(0);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject); 
            }

            if (isMelon)
            {
                LevelManager.instance.melonCollected++; 

                UIController.instance.UpdateMelonCount(); 
                AudioManager.instance.PlaySFX(0);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject); 
            }

            if (isHeal)
            {
                //Si la vida del player es distintas a la máxima (es decir no tiene toda la vida), hace los siguiente:
                if (PlayerHealthControler.Instance.currentHealth != PlayerHealthControler.Instance.maxHealth)
                {
                    PlayerHealthControler.Instance.HealPlayer(); //Llama a la función de curar al layer
                    AudioManager.instance.PlaySFX(1); //Pone el efecto de sonido de curación

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
