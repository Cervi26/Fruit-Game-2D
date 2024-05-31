using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string nextLevel; //Creamos variable para nombrar al nivel al que cambiaremos


    //Al chocar el player contra el objeto de "end" activa la función de waitAmomEnd
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //verifica que sea el Player quien colisiona
        {
            waitAmomEnd();
        }
    }


    //Se crea la función que se encarga de llamar a una corrutina
    public void waitAmomEnd()
    {
        StartCoroutine(WAmomEnd());
    }

    //Se crea la corrutina que se encarga de lo siguiente:
    IEnumerator WAmomEnd()
    {
        AudioManager.instance.PlaySFX(3); //Repoducir el efecto de sonido de fin de nivel
        yield return new WaitForSeconds(1); //Epserar 1 segundo
        SceneManager.LoadScene(nextLevel); //Movernos a la siguiente escena, definida anteriormente en unity

    }
}
