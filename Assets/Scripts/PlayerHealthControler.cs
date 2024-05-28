using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControler : MonoBehaviour
{
    public static PlayerHealthControler Instance;

    public int currentHealth, maxHealth; //De esta manera poder llevar el conteo de la vida que tenemos y la que podemos tener.

    public float invicibleLength; // Duracion de la invicibilidad  
    public float invicibleCounter; // Contador de la invicibilidad

    private SpriteRenderer theSR;

    private void Awake()
    {
          Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; ; //Para empezar con toda nuestra vida.

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibleCounter > 0) 
        {
            invicibleCounter -= Time.deltaTime;

            if(invicibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage() // Estp es el daño que le vamos a quitar a jugador.

    {

        if (invicibleCounter <= 0)
        {
            currentHealth--; //Con el simbolo --, reducimos la vida al verlo.

            if (currentHealth <= 0) // aqui estamos diciemdo que si no tenemos vidas y nos quitan una empezamos de nuevo.
            {
                currentHealth = 0;

                gameObject.SetActive(false); // hacemos lo inicial para poder hacerle daño al jugador.
            }

            else 
            {
                invicibleCounter = invicibleLength;  //Cuando nos empiecen a golpear, nos va a decir que nos hace invencibles durante un tiempo
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 5f);

                PlayerController.instance.Knockback();

            }

            UIController.instance.UpdaterHealthDisplay();
        }
    }
}
