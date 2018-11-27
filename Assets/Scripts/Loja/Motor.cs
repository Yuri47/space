using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Motor : MonoBehaviour
{


    private int amountCoins;

    //motor
    private int valorMotor;
    public Text textoValorMotor;
    int[] tabelaMotor = new int[] { 100, 300, 600, 1000, 5000, 6000, 7000, 8000, 0 };//o ultimo valor não entrará na conta
    public Button botaoMotor;
    public GameObject coin;

    // Use this for initialization
    void Start()
    {
        
        amountCoins = PlayerPrefs.GetInt("amountCoins");

    }

    // Update is called once per frame
    void Update()
    {
        amountCoins = PlayerPrefs.GetInt("amountCoins");


       
        valorMotor = tabelaMotor[Mathf.CeilToInt(PlayerPrefs.GetFloat("engine") * 10) - 1];
        textoValorMotor.text = valorMotor.ToString();

        if (Mathf.CeilToInt(PlayerPrefs.GetFloat("engine") * 10) - 1 == tabelaMotor.Length - 1)
        {
            botaoMotor.interactable = false;
            textoValorMotor.enabled = false;
            coin.SetActive(false);
        }

         
    }


    //Itens



    public void ComprarMotor()
    {
        var aux = PlayerPrefs.GetFloat("engine");
     

        if (valorMotor <= amountCoins)
        {

            PlayerPrefs.SetInt("amountCoins", amountCoins - valorMotor);
            PlayerPrefs.SetFloat("engine", aux + 0.1f);

        }
        
    }


}