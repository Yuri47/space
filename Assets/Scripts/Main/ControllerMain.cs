using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerMain : MonoBehaviour {

    //private PlayerMovement player;
     


    public Text coins;



    private void Awake()
    {
        //player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        Time.timeScale = 1;
        //verifica se existe o player prefs chamado engine, se não existir ele é criado.
        if (!PlayerPrefs.HasKey("engine"))
        {
            PlayerPrefs.SetFloat("engine", 0.1f);
        }
        if (!PlayerPrefs.HasKey("amountCoins"))
        {
            PlayerPrefs.SetInt("amountCoins", 0);
        }
        if (!PlayerPrefs.HasKey("velocity"))
        {
            PlayerPrefs.SetInt("velocity", 5);
        }
    }

    // Use this for initialization
    void Start () {
      



    }
	
	// Update is called once per frame
	void Update () {
        coins.text = PlayerPrefs.GetInt("amountCoins").ToString();
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void main()
    {
        SceneManager.LoadScene("Main");
       // SceneManager.UnloadSceneAsync("Main");
    }
    public void loja()
    {
       SceneManager.LoadScene("Store");
       // SceneManager.UnloadSceneAsync("Store");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Resetar()
    {
        PlayerPrefs.SetInt("amountCoins", 0);
        PlayerPrefs.SetFloat("engine", 0.1f);
        PlayerPrefs.SetInt("velocity", 1);
    }
    public void Coins()
    {
        PlayerPrefs.SetInt("amountCoins", PlayerPrefs.GetInt("amountCoins") + 100000);
    }



}
//player.altitude.ToString()