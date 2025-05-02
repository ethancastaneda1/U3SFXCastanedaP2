using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private int obstacleIndex;
    private float startDelay = 2;
    private float repeatRate = 2;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        obstacleIndex = Random.Range(0, 2);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);                               
        }
        repeatRate = Random.Range(1f, 2.5f);
        startDelay = Random.Range(1f, 2.5f);
        CancelInvoke();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
}