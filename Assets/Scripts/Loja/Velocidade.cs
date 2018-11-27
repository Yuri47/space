using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Velocidade : MonoBehaviour {


    private int amountCoins;

    //motor
    private int valorVelocidade;
    public Text textoValorVelocidade;
    int[] tabelaVelocidade = new int[] { 100, 300, 600, 1000, 5000, 6000, 0 }; //o ultimo valor não entrará na conta
    public Button botaoVelocidade;
    public GameObject coin;
     




    private void Awake()
    {
         
    }

    // Use this for initialization
    void Start()
    {

        amountCoins = PlayerPrefs.GetInt("amountCoins");

    }

    // Update is called once per frame
    void Update()
    {
        amountCoins = PlayerPrefs.GetInt("amountCoins");



        valorVelocidade = tabelaVelocidade[PlayerPrefs.GetInt("velocity") - 1];
        textoValorVelocidade.text = valorVelocidade.ToString();

        if (PlayerPrefs.GetInt("velocity")   == tabelaVelocidade.Length  )
        {
            botaoVelocidade.interactable = false;
            textoValorVelocidade.enabled = false;
            coin.SetActive(false);
        }

        Debug.Log("Velocity: " + (PlayerPrefs.GetInt("velocity") ).ToString());
        Debug.Log("Tabela: " + tabelaVelocidade.Length);
        Debug.Log("Player: " ); 
    }


    //Itens



    public void ComprarVelocidade()
    {
        var aux = PlayerPrefs.GetInt("velocity");


        if (valorVelocidade <= amountCoins)
        {

            PlayerPrefs.SetInt("amountCoins", amountCoins - valorVelocidade);
            PlayerPrefs.SetInt("velocity", aux + 1);

        }

    }


}