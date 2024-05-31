using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Se declaran las variables que se encargan de nombrar a cada una de las escenas
    public string startScene;
    public string credits;

    //Carga la escena de comienzo, para asignarlo en el OnClick desde unity
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    //Carga la escena de creditos, para asignarlo en el OnClick desde unity
    public void creditsScene()
    {
        SceneManager.LoadScene(credits);
    }

    //Cuando se ejecuta cierra el juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
