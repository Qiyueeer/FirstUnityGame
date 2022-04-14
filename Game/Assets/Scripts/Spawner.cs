using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;
    public GameObject[] obstacleTemplate;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, obstacleTemplate.Length);
            Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime)
            {
                startTimeBtwSpawns -= timeDecrease;
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
