using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{

    public float Health = 100f;
    public GameObject DeathUI;
    // Start is called before the first frame update
    public void GameOver()
    {
        UnityEngine.Debug.Log("isDead");
        DeathUI.SetActive(true);
        Time.timeScale = 0f;
    }
   
}
