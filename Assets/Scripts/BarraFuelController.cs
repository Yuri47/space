using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraFuelController : MonoBehaviour {


    public float fuel;
    public Texture barraFuel, contorno;
    public float fuelCheio = 100f;
    private PlayerMovement player;
    



    void Awake(){
        player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
    }

    // Use this for initialization
    void Start () {
        fuel = fuelCheio;
	}
	
	// Update is called once per frame
	void Update () {
        if (fuel >= fuelCheio){
            fuel = fuelCheio;
        } else if (fuel <= 0) {
            fuel = 0;
        }

        fuel = player.fuel;

	}

    void OnGUI(){//desenha a barra de vida e o contorno na tela
        GUI.DrawTexture(new Rect(Screen.width / 1.8f, Screen.height / 52f, Screen.width / 2.3f / fuelCheio * fuel, Screen.height / 19f), barraFuel);
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 100, Screen.width / 2, Screen.height / 14), contorno);
        GUI.Label(new Rect(Screen.width / 3, Screen.height / 100, Screen.width / 2, Screen.height / 14), "estring");
    }


    

}
