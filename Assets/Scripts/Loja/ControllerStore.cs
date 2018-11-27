using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerStore : MonoBehaviour {

    public Text coins;
    private int amountCoins;

     
     
      

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        //amountCoins = PlayerPrefs.GetInt("amountCoins");
        coins.text = PlayerPrefs.GetInt("amountCoins").ToString();

        
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


}
