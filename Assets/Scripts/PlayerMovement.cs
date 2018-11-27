using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float maxVelocityX = 3f;
    public float maxVelocityY;
    public float velocidadeMaxima;
    private bool grounded;
    public bool estaNoChao;
    public float flySpeed = 15f;
    public float airSpeed = 1.3f; //controla a velocidade X
    public float fuel = 10f;
    public float motor = 0.2f;
    private float motorStore;
    private int velocityStore;


    //private float resultAcX;
    public float velocidadeX = 0;

    private float auxDeltaTime;
    public float tempoRegressivo; //auxilia na quantidade de combustível
    private float coletouCombustivel;
    public float valorCombustivel;

    public int quantidadeCombustivel = 0;

    public GameObject panelDead;
    public GameObject panelGame;
    public GameObject panelFuel;
    public GameObject explosion;
    public GameObject nave;

     
    public int quantidadeGold = 0;
     

    public float altitude = 0;


    private Rigidbody2D myBody;
    private PlayerMovement pl;
    private PauseController ps;

    private MovementController movementController;

    public bool pause;
    public float pegarAlturaMaxima;

    public static int moveSide;
    public int verValorMoveSide;

    public float distanciaPercorrida;
    private Vector3 pontoInicial;

    public GameObject t1;

    public Transform spritePlayer;
    private Animator animator;
    public int coins;
    public static float posicaoY;

    private bool verificaAltura; //se a nave passar da altura 0 fica true

    


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        pl = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        movementController = GetComponent<MovementController>();
        ps = FindObjectOfType(typeof(PauseController)) as PauseController;
        pause = false;
        estaNoChao = true;
        panelDead.SetActive (false);
         
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        pontoInicial = transform.position;
        verificaAltura = false;
    }

    void Start()
    {
        
        tempoRegressivo += PlayerPrefs.GetInt("compraFuel");
        
        flySpeed += PlayerPrefs.GetInt("compraAceleracao");
        moveSide = 0;
        try { 
        animator = nave.GetComponent<Animator>();
        } catch {  }
        motorStore = PlayerPrefs.GetFloat("engine");
        
        velocityStore += PlayerPrefs.GetInt("velocity");
        maxVelocityY += velocityStore * 5;
        motor += motorStore - (velocityStore * 0.1f);


    }

    void Update()
    {

        /*
            Rect Esquerda = new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
            Rect Direita = new Rect (Screen.width / 2 , Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
            foreach (Touch t in Input.touches) {
                Vector2 vec = t.position;
                vec.y = Screen.height - vec.y; 
                if (Esquerda.Contains (vec)) {
                    t1.SetActive (false);
                }
                if (Direita.Contains (vec)) {
                    t1.SetActive (true);
                }
            }

            */
        posicaoY = myBody.transform.position.y;
         
        try { 
        if (estaNoChao == true)
        {
            animator.SetBool("MotorLigado", true);
            movementController.movement.x = 0; //não deixa mover a nave no eixo X se o motor estiver desligado
        }
        else
        {
            animator.SetBool("MotorLigado", false);
        }
        }
        catch { }

        distanciaPercorrida = Vector3.Distance(transform.position, pontoInicial);

        verValorMoveSide = moveSide;

        altitude = (pl.transform.position.y / 2 / 10)+.18f ; // 10;
         
        if (altitude < 0 )
        {
            altitude = 0;
        }

        if (movementController.movement.y > 0)
        {

            estaNoChao = false;
        }
        else
        {
            estaNoChao = true;
        }







        //###########################  Combustível  ########################## 


        fuel = (tempoRegressivo - auxDeltaTime) + coletouCombustivel; //combustivel da nave

        if (fuel <= 0)
        { // se o combustivel chegar a 0 a nave cai
            movementController.movement.y = 0;
            estaNoChao = true; //desliga a nave por falta de combustivel

        }
















        var forceX = 0f;
        var forceY = 0f;

        var absX = Mathf.Abs(myBody.velocity.x);
        var absY = Mathf.Abs(myBody.velocity.y);

       // float acX = Input.acceleration.x * 10; // pega o valor do acelerometro e multiplica por 10

        velocidadeMaxima = myBody.velocity.y;
        velocidadeX = myBody.velocity.x;


        if (absY < .2f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (Time.timeScale > 0)
        {
            if (movementController.movement.x != 0)
            {

                if (absX < maxVelocityX)
                {
                    /*
                    if (resultAcX > 0)
                    {
                        speed = resultAcX;
                    }
                    */
                    if (grounded)
                    {
                        forceX = speed * movementController.movement.x;
                    }
                    else
                    {
                        forceX = speed * movementController.movement.x * airSpeed;
                    }

                }


                if (forceX > 0)
                { //movimento lateral
                  // transform.localScale = new Vector3(1, 1, 1);
                }
                else if (forceX < 0)
                {
                    // transform.localScale = new Vector3(-1, 1, 1);
                }

            }

        }



        if (Time.timeScale > 0)
        {
            if (movementController.movement.y != 0)
            {

                auxDeltaTime -= Time.deltaTime * (-1) / motor; // controle do combustivel. Esse numero 1 será o tipo de motor, quanto
                                                               //maior o numero mais devagar o combustivel será queimado.
                if (absY < maxVelocityY)
                {

                    forceY = flySpeed * movementController.movement.y;

                }

            }
            else if (absY > 0)
            {

            }
        }

        myBody.AddForce(new Vector2(forceX, forceY)); //controla as direções x e y da nave


        //###########################################################################################################
        if (Time.timeScale > 0)
        {

            if (velocidadeX > 0)
            { //controla o avanço lateral, não deixa ir infinitamente.
                myBody.AddForce(Vector3.left * 3);

                if (velocidadeX < 0.12f)
                {
                    velocidadeX = 0;
                    absX = 0;
                }
            }
            else if (velocidadeX < 0)
            {
                myBody.AddForce(Vector3.right * 3);
                if (velocidadeX > -0.12f)
                {
                    velocidadeX = 0;
                    absX = 0;
                }
            }



            /*
            if (acX < 0f)
            { // controle do acelerometro deixando sempre positivo
                resultAcX = acX * (-1);
            }
            else
            {
                resultAcX = acX;
            }
            */
        }

        if (myBody.transform.position.y > 0)
        {
            verificaAltura = true;
        }

        if (altitude > pegarAlturaMaxima) { 
        pegarAlturaMaxima = altitude;
        }

    }




    void OnCollisionEnter2D(Collision2D coll)
    { //colição com os combustiveis.
        if (coll.gameObject.tag == "fuel")
        {
            Destroy(coll.gameObject);

            var temp = 0f;

            //o código abaixo não deixa que o combustível ultrapasse 100, sendo assim, se o valorCombustivel for igual a 40 e o
            //combustivel atual for igual a 90, o combustível valerá apenas 10.
            if (fuel >= 100)
            {
                coletouCombustivel += 0;

            }
            else if (fuel < 100)
            {
                if ((fuel + valorCombustivel) > 100)
                {
                    temp = 100 - fuel;
                    coletouCombustivel += temp;

                }
                else if ((fuel + valorCombustivel) < 100)
                {
                    coletouCombustivel += valorCombustivel;
                }
            }


        }
        if (coll.gameObject.tag == "gold")
        {
            Debug.Log("Gold!!!");
            quantidadeGold++;
            Destroy(coll.gameObject);
        }
        if (verificaAltura == true && coll.gameObject.tag == "chao")
        {
             
             Morreu ();

        }


    } // colisão
       
      void Morreu() {


        coins = Mathf.CeilToInt((pegarAlturaMaxima * 10)*2f);
        PlayerPrefs.SetInt("amountCoins", PlayerPrefs.GetInt("amountCoins") + coins);
        ps.Pausar();
        panelDead.SetActive(true);
        panelGame.SetActive(false);
        panelFuel.SetActive(false);
        coletouCombustivel = -20000;
        explosion = Instantiate(explosion) as GameObject;
        explosion.transform.position = new Vector2(myBody.transform.position.x,myBody.transform.position.y);
        Destroy(nave);
        /*
           
          panelDead.SetActive (true);
          panelGame.SetActive (false);
          PlayerPrefs.SetInt ("quantidadeCombustivel", quantidadeCombustivel + tempAux); 
          PlayerPrefs.SetInt ("quantidadeTotalGold", quantidadeGold + quantidadeTotalGold);
          */

        Debug.Log("morreu");
      }

      


} // PlayerMovement








/*
 * 
 * 
 * 
 *                  Debug.Log("<color=orange>FUEL do IF: </color>"+ fuel + 40);
                    Debug.Log("<color=green>Valor Somado: </color>"+ temp);
                    Debug.Log("<color=blue>FUEL:</color>" + fuel);
 * 
 * 
 * 
 * 
 * 
 */

