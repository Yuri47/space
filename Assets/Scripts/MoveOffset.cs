using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {

    public GameObject player;
    private SpriteRenderer sprite;
    public float offset = 1f;
    private float time;
    private float posicaoPlayer;
    // Use this for initialization
    void Awake () {
		sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        posicaoPlayer = player.transform.position.y;
         time += Time.deltaTime;
        var pos = new Vector2(0, posicaoPlayer/offset);
        sprite.transform.position = pos;
      //  sprite.flipY =true;

    }
}
