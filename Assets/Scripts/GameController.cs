using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public WayRoute[] wayroutes;
    public GameObject[] invaders;
    public Transform prefabFar;
    public Transform prefabNear;

    public int totalRounds = 5;
    public int currentRound;

    public float timer;
    public float spawnGapBetweenRounds;
    public float spawnGapWithinRound;

	// Use this for initialization
	void Start () {
        currentRound = 1;
        timer = 0.0f;


	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
		
	}

    public void endGame()
    {

    }
}
