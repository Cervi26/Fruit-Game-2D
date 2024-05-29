using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToRespawn;

    public int appleCollected; // Para el conteo de las manazanas recolectadas.
    public int cherriesCollected; // Para el conteo de las cerezas recolectadas.
    public int melonCollected; // Para el conteo de los melones recolectadas.

    private void Awake()
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

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = checkPointController.instance.spawnPoint;

        PlayerHealthControler.Instance.currentHealth = PlayerHealthControler.Instance.maxHealth;

        UIController.instance.UpdaterHealthDisplay();

    }
}
