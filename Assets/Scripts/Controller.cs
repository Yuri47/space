using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    private PlayerMovement player;
    private MovementController mv;
    public Image ponteiroVelocimetro;
    public float velocimetroMultiply;
    public Text textoAlturaMaxima, moedas, coins;
     
    


    public Text altura;



    private void Awake()
    {
        player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        mv = FindObjectOfType(typeof(MovementController)) as MovementController;
        coins.text = PlayerPrefs.GetInt("amountCoins").ToString();

    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
         

        //Altitude
        altura.text = string.Format("{0:0.00}", player.altitude) + "km";
        textoAlturaMaxima.text = string.Format("{0:0.00}", player.pegarAlturaMaxima)+"km";
        


        //Velocimetro
        var velocidadeNave = player.velocidadeMaxima;
        if (velocidadeNave <= 0)
        {
            velocidadeNave = 0;
        }
        ponteiroVelocimetro.transform.eulerAngles = new Vector3(0, 0, (-velocimetroMultiply * velocidadeNave) + 90);


        //Moedas
        //moedas.text = PlayerPrefs.GetInt("amountCoins").ToString();
        moedas.text = player.coins.ToString();

    }

    public void play()
    {
         
        SceneManager.LoadScene("Game");
    }
    public void main()
    {
         
        SceneManager.LoadScene("Main");
    }
    public void loja()
    {
        
        SceneManager.LoadScene("Store");
    }
    public void TurnOnOff()
    {
        mv.verfToggle = !mv.verfToggle;
    }



}
//player.altitude.ToString()