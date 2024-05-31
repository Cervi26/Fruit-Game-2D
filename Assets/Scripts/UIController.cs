using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance; //Lo hacemos instancia para que sea accesible desde otro script

    public Image heart1, heart2, heart3; //Hacemos referencia a las imagenes que se usarán

    public Sprite heartFull, heartEmpty; //Hacemos referencia a los estados que tendrán las vidas en el UI

    public Text AppleText, CherriesText, MelonText; //Los textos que mostrarán los contadores de frutas


    private void Awake() //declaramos la instancia con el awake
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //Cada vez que comienza la scene, actualiza los 3 contadores
       UpdateAppleCount();
       UpdateCherriesCount();
       UpdateMelonCount();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Aquí tenemos un switch, que se encarga de representar todos los posibles escenarios, con todas las posibles vidas que el player puede tener, mientras
    //pierde vidas o las va sumando.
    public void UpdaterHealthDisplay()
    {
        switch (PlayerHealthControler.Instance.currentHealth)
        {
            //Toda todas las vidas
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            //Tiene 2 vidas
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;
            //Tiene 1 vida 
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
            //No tiene vidas
            case 0:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            //El case default para fallos
            default:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break; //Cerrar el switch
        }
    }

    public void UpdateAppleCount() // Tenemos que llamar a esta funcion cada vez que cogemos una fruta y para ello lo debemos de hacer desde Pickup.
    {
        AppleText.text = LevelManager.instance.appleCollected.ToString(); // Lo que hacemos mencion del LevelManager para poder coger de aqui la linea de codigo para el text del contador.

    }

    public void UpdateCherriesCount() // Tenemos que llamar a esta funcion cada vez que cogemos una fruta y para ello lo debemos de hacer desde Pickup.
    {
        CherriesText.text = LevelManager.instance.cherriesCollected.ToString(); // Lo que hacemos mencion del LevelManager para poder coger de aqui la linea de codigo para el text del contador.

    }

    public void UpdateMelonCount() // Tenemos que llamar a esta funcion cada vez que cogemos una fruta y para ello lo debemos de hacer desde Pickup.
    {
        MelonText.text = LevelManager.instance.melonCollected.ToString(); // Lo que hacemos mencion del LevelManager para poder coger de aqui la linea de codigo para el text del contador.

    }
}

