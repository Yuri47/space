using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementController : MonoBehaviour {

	public Vector2 movement = new Vector2(0, 0);
	//public bool verificarOnOff;
	//private onoffController onoff;
	public bool verfToggle = false;
	//private pauseController psc;
	public static int moveSide;
     
    
    public  bool play;
    private bool esq, dir, aux = false;

	void Start() {
      
        
        play = false;
    }

	void Update () {
       
         

		movement.x = movement.y = 0f;

        //Controle Touch
        Rect Esquerda = new Rect(Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 3.3f, Screen.width / 2, Screen.height / 1.2f);
        Rect Direita = new Rect(Screen.width / 2, Screen.height / 2 - Screen.height / 3.3f, Screen.width / 2, Screen.height / 1.2f);

        foreach (Touch t in Input.touches)
        {
            Vector2 vec = t.position;
            vec.y = Screen.height - vec.y;
            if (Esquerda.Contains(vec))  { 
              
                esq = true;
                aux = true;
            }  

            if (Direita.Contains(vec))  {
             
                dir = true;
                aux = true;
            }  

        }

        if (Input.touchCount == 0) //verifica se está tocando na tela
        {
            dir = false;
            esq = false;
            aux = false;
        }

         






        if (Input.GetKey ("right") || Input.GetKey ("d") || moveSide == 1 || dir == true) {
			movement.x = 1f;
            aux = true;
        } else if(Input.GetKey ("left") || Input.GetKey ("a") || moveSide == -1 || esq == true) {
			movement.x = -1f;
            aux = true;
        }
        if (aux == false)
        {
            movement.x = 0;
        }
         


        if (Input.GetKey ("up") || Input.GetKey ("w") || verfToggle == true) {
			movement.y = 1f;
		} else if(Input.GetKey ("down") || Input.GetKey ("s")) {
			//movement.y = -1f;
		}
        if (Input.GetKeyDown("x") || Input.GetKeyDown("space") || play == true)
        {
            verfToggle = !verfToggle; 
        }
		 

		 
	
	}

} // MovementController
