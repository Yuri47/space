using UnityEngine;
using System.Collections;

public class SpawnFuelController : MonoBehaviour
{

    public GameObject fuelPrefab;
    public float rateSpawn;
    public float currentTime;
    private int posicao;
    private float y;
    private float x;
    private PlayerMovement player;
    public float posicYPlayer;
    public float tempoDestruir;
    public float distanciaEntreSpawn;
    public bool pare = false;

    public float distanciaSpawnPlayer;

    // Use this for initialization
    void Start()
    {
        currentTime = 0;

        //y = 3f;

        player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;


    }

    // Update is called once per frame
    void Update()
    {
        posicYPlayer = player.transform.position.y;
        if (y <= (posicYPlayer + distanciaSpawnPlayer))
        {
            currentTime += Time.deltaTime;

            if (currentTime >= rateSpawn)
            {
                currentTime = 0;
                y += distanciaEntreSpawn;
                x = Random.Range(-2.35f, 2.35f);

                GameObject tempPrefab = Instantiate(fuelPrefab) as GameObject;
                tempPrefab.transform.position = new Vector2(x, y);
                Destroy(tempPrefab.gameObject, tempoDestruir);
            }
        }
    }




}