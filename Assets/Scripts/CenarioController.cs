using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenarioController : MonoBehaviour {

    public GameObject P;
    private float player;
    public GameObject   grama, arvoreFundo, arvoreFrente, montanhaFundo, montanhaFrente;
    public float auxGrama, auxArvoreFundo, auxArvoreFrente, auxMontanhaFundo, auxMontanhaFrente;
    public Camera panel;
    [Range(0f, 1f)]
    public float slid;
    private Color tempColor;




    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        //  tempColor = panel.color;
       // panel.backgroundColor = Color.HSVToRGB(227, 100, 100);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
        player = P.transform.position.y;
       // ceu.transform.position = new Vector2(-1.509677f, ((player) / 1.02f)+20  );
        grama.transform.position = new Vector3(0, ((player) / auxGrama), 87.29f);
        arvoreFundo.transform.position = new Vector3(0, ((player) / auxArvoreFundo), 88.43f);
        arvoreFrente.transform.position = new Vector3(0, ((player) / auxArvoreFrente), 87.81f);
        montanhaFundo.transform.position = new Vector3(0, ((player) / auxMontanhaFundo), 89.51f);
        montanhaFrente.transform.position = new Vector3(0, ((player) / auxMontanhaFrente), 89.06f);


       // var aux = (100- ((-player - 3.7f)/10 )*-1);
        var aux = 1.4f + ((player * -1) / 1000);
        tempColor.a = aux;
        //panel.color = tempColor;
        panel.backgroundColor = Color.Lerp(Color.black, Color.blue, aux);
        Debug.Log("aux: "+aux);
        var aux2 = 1.4f+((player *-1)/1000);
        Debug.Log("player: " + aux2);
         
	}
}
