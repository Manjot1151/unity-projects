using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGeneration : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate;
    public int spawnAmount;
    public float spawnDistance;
    public float trajectoryVariance;
    void Awake()
    {
        spawnRate = 5.0f;
        spawnAmount = 3;
        spawnDistance = 25.0f;
        trajectoryVariance = 15.0f;
    }
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnRate);
    }

    void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            Quaternion rotation = Quaternion.AngleAxis(Random.Range(-trajectoryVariance, trajectoryVariance), Vector3.forward);
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.Throw(rotation * -spawnDirection);
        }
    }
}
