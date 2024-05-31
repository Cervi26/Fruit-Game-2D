using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static PauseMenu instance; //Se hace instancia para poder usarlo en otros scripts

    public GameObject pauseMenu; //Variable del propio men� de pausa
    public string MainScene; //Variable de la scene que se cargar� al darle a exit
    public bool isPaused; //Boleano para saber si el juego est� o no pausado

    void Awake() //Awake que sirve para la instancia que se creo anteriormente
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Con este if, hacemos que cada vez que se pulse la tecla de escape:
        if (Input.GetKeyDown("escape"))
        {
            PauseUnpause();//Ejecute la funci�n
        }
    }


    //Esta funci�n, se encarga de ver si est� pausado o no e juego y reliazra una serie de acciones
    public void PauseUnpause()
    {
        if (isPaused)  //Si el juego est� pause:
        {
            isPaused = false; //Pone la variable en pause
            pauseMenu.SetActive(false); //Quita de la pantalla el men� de pause
            Time.timeScale = 1f; //Pone el tiempo del juego a funcionar
        }
        else //Si no est� en pause:
        {
            isPaused=true; //Pone la variable en pause
            pauseMenu.SetActive(true); //Muestra el men� de pause en pantalla
            Time.timeScale = 0f; //Pone el tiempo en 0, es decir congelado
        }
    }

    //Esta funci�n, sirve pata que al pulsar en e bot�n de salir del nivel, nos lleve al main manu del juego
    public void exitSelect()
    {
        SceneManager.LoadScene(MainScene); //Cargar la escena que queremos
        Time.timeScale = 1f; //Poniendi esto, se vuelve a poner el juego en marcha despu�s de salir al men� y entrar de nuevo al juego.
    }
}
