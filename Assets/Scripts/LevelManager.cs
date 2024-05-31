using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance; //Se declara instancia para usarlo en otros scripts

    public float waitToRespawn; //Variable para poner cuantos segundos se va a esperar

    public int appleCollected; // Para el conteo de las manazanas recolectadas.
    public int cherriesCollected; // Para el conteo de las cerezas recolectadas.
    public int melonCollected; // Para el conteo de los melones recolectadas.

    private void Awake()
    {
        instance = this; //Awake de la instancia
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Función que llama a una corrutina
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    //Corrutina que se encarga de:
    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false); //Poner el objeto de "player" como false para no verlo
        yield return new WaitForSeconds(waitToRespawn); //Se espera el tiempo que se hay apuesto en esa variable en unity

        PlayerController.instance.gameObject.SetActive(true); //Se vuelve a poner al player como visible

        //Se mueve el transform del player (y por ende el propio objeto de player a la posición guardada del checkpoint)
        PlayerController.instance.transform.position = checkPointController.instance.spawnPoint;

        //se iguala la vida del jugador con la máxima (restablece toda la vida al player)
        PlayerHealthControler.Instance.currentHealth = PlayerHealthControler.Instance.maxHealth; 

        UIController.instance.UpdaterHealthDisplay(); //Actualiza los corazones del canvas con toda la vida después de reaparecer

    }
}
