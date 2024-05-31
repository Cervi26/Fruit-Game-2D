using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //Se ejecuta cuando el player, colisiona contra este objeto

    {
        if (other.tag == "Player")
        {
            PlayerHealthControler.Instance.DealDamage(); //Cada vez que se ejecuta, se llama a la función de DealDamage que se encarga de dañar al player
        }
    }
}
