using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControler : MonoBehaviour
{
    public static PlayerHealthControler Instance; //Instancia para poder usarla en otros scripts

    public int currentHealth, maxHealth; //De esta manera poder llevar el conteo de la vida que tenemos y la que podemos tener.

    public float invicibleLength; // Duracion de la invicibilidad  
    public float invicibleCounter; // Contador de la invicibilidad

    private SpriteRenderer theSR; //Hace referencia al Sprite Renderer

    public GameObject deathEffect; //Hace referencia al efecto de muerte para el player 

    private void Awake()
    {
          Instance = this; //Awake de la instancia
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; ; //Para empezar con la vida al completo, iguala la vida del player con la máxima.

        theSR = GetComponent<SpriteRenderer>(); //Variable para hacer referencia al sprite del player
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibleCounter > 0) 
        {
            invicibleCounter -= Time.deltaTime;

            if(invicibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f); //Esto hace que cambie la opacidad del player
            }
        }
    }

    public void DealDamage() // Estp es el daño que le vamos a quitar a jugador.

    {

        if (invicibleCounter <= 0)
        {
            currentHealth--; //Con el simbolo --, reducimos la vida del player en 1
            AudioManager.instance.PlaySFX(4); //Se activa el efecto de sonido de recibir daño

            if (currentHealth <= 0) // Si las vidas del player son iguales o menores que 0:
            {
                currentHealth = 0; //Se iguala a 0 vidas

                //Posición donde aparece el efecto de muerte de player
                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

                LevelManager.instance.RespawnPlayer(); //Se ejecuta la fucnión que se encarga de Respawnear al player tras morir
            }

            else //Si no:
            {
                invicibleCounter = invicibleLength;  //Cuando nos empiecen a golpear, nos va a decir que nos hace invencibles durante un tiempo
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 5f);

                PlayerController.instance.Knockback();//Se ejecuta el knockback, que es un pequeño golpe hacia atrás.

            }

            UIController.instance.UpdaterHealthDisplay(); //Se actualizan las vidas en el canvas o UI
        }
    }


    //Función que se encarga de curra al player
    public void HealPlayer()
    {
        currentHealth++; //Añadimos una vida al player

        if(currentHealth > maxHealth) //Si la vida del player, es mayor que la maxima:
        {
            currentHealth = maxHealth; //Se iguala para que el player tenga la máxima vida, pero no más.
        }

        UIController.instance.UpdaterHealthDisplay(); //se actualiza de nuevo las vidas en el canvas UI
    }
}
