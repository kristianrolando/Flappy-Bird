using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    [SerializeField] GameObject[] pipePrefabs;
    [SerializeField] GameObject[] pointWays;

    [HideInInspector] public float timeSpawn;

    Bird bird;
    float time;
    private void Start()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
    }

    void Update()
    {

        if (bird.isPlayed)
        {
            if (time <= 0)
            {
                Spawn();
                time = timeSpawn;
            }
            else
            {
                time -= Time.deltaTime;
            }
        } 
    }

    void Spawn()
    {
        int ranPoint = Random.Range(0, pointWays.Length);
        int ranPrefabs = Random.Range(0, pipePrefabs.Length);
        Instantiate(pipePrefabs[ranPrefabs], pointWays[ranPoint].transform.position, Quaternion.identity);
    }

}
