using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float ValorSuavizacao;
    public float offset;

    void Start()
    {

    }

    void Update()
    {
        //Time.timeScale = 1;

        Vector3 positionPlayer;
        positionPlayer = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, positionPlayer, ValorSuavizacao);
    }
}