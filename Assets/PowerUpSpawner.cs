﻿using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject[] powerUpSpawnPoints;
    public static bool powerUpActive;

    GameManager gameManager;
    TheWaveManager waveManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveManager = GameObject.Find("WaveManager").GetComponent<TheWaveManager>();
    }

	void Update ()
    {
	    if(!powerUpActive)
        {
            powerUpActive = true;
            int randomPowerUp = Random.Range(0, powerUps.Length);
            int randomSpawnLocation = Random.Range(0, powerUpSpawnPoints.Length);
            GameObject powerUp = Instantiate(powerUps[randomPowerUp], powerUpSpawnPoints[randomSpawnLocation].transform.position, Quaternion.identity) as GameObject;
            waveManager.ChangeSpawns(powerUpSpawnPoints[randomSpawnLocation]);
            foreach(GameObject go in gameManager.players)
            {
                go.GetComponentInChildren<LookAt>().target = powerUp;
            }
        }
	}
}
