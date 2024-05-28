using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance; //Lo hacemos estatico para que sea accesible desde otro punto porque es una instancia.

    public Image heart1, heart2, heart3; //Hacemos referencia a las imagenes.

    public Sprite heartFull, heartEmpty, heartHalf; //Hacemos referencia a las vidas.

    private void Awake() //declaramos la instancia
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdaterHealthDisplay()
    {
        switch (PlayerHealthControler.Instance.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 0:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            default:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }
    }
}

