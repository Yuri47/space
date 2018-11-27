using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocimetro : MonoBehaviour {


    public float AnguloMultipler ;

    public float Carro = 5;

    public float Velocidade;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Velocidade = (Carro * AnguloMultipler);



        transform.eulerAngles = new Vector3(0, 0, Velocidade);

        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 50), "Km/h: " + (int)Velocidade);
    }
}
