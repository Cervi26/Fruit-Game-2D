using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance; //Se hace instancia

    public AudioSource[] soundEffects; //Se declara una matriz para meter los efectos de sonido

    public AudioSource mainMusic; //Se declara una variable para la musica que sonará en el nivel

    private void Awake()
    {
        instance = this; //El awake de la instancia
    }

    //En este caso no se usa el start
    void Start()
    {
        
    }

    //tampoco el update
    void Update()
    {
        
    }

    //Esta es la fucniñon que se encarga de reproducir los efectos de sonido. Como parametro entra un numero referente al sonido dentro de la matriz
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play(); 
    }
}
