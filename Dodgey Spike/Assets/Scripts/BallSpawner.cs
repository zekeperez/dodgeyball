using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner instance;
    public Transform playerBall;
    public GameObject enemyPrefab;
    public Transform[] ballSpawnLocations;
    public float frequency;
    public float offset;
    float decaySpeed = 0.015f;

    bool active = false;

    float ballForce = 75f;

    //Statistics
    int totalSpawned = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startSpawn();
    }

    private void Update()
    {
        if(frequency > 0) { frequency -= Time.deltaTime * decaySpeed; }
        if (frequency < 0) { frequency = 0.1f; }

        if(ballForce > 0) { ballForce += Time.deltaTime * (decaySpeed * 2); }
        if(ballForce < 0) { ballForce = 0.1f; }
    }

    public void startSpawn()
    {
        active = true;
        StartCoroutine(spawnLoop());
    }

    public void stopSpawn()
    {
        active = false;
        StopCoroutine("spawnLoop");
    }

    IEnumerator spawnLoop()
    {
        while (active)
        {
            yield return new WaitForSeconds(frequency);

            if (active)
            {
                Vector3 spawnPos = ballSpawnLocations[Random.Range(0, ballSpawnLocations.Length)].position;

                GameObject newSpike = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                Enemy enemy = newSpike.GetComponent<Enemy>();
                enemy.launch(ballForce, playerBall);

                totalSpawned++;
            }
            
        }
    }
}
