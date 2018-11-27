using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

	public static bool verif = false;
	public Toggle tog;
	 
	public GameObject painelPause;
    public static bool pause;
	// Use this for initialization
	void Start () {
        pause = false;
        Time.timeScale = 1;
        tog.isOn = false; 
	}

	// Update is called once per frame
	void Update () {
        if(tog.isOn) {
            Pausar();
            painelPause.SetActive(true);
        }else {
            Despausar();
            painelPause.SetActive(false);
        }
 
         
	}

	public void Pausar () {
        Time.timeScale = 0;
        pause = true;
	}

	public void Despausar() {
        Time.timeScale = 1;
        pause = false;
	}
	public static bool GetPause() {
		 return pause;
	}

     
}
