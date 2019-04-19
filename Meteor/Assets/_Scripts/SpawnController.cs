using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    

    [Header("Game Design - Spawn")]
    public float spawnRangeMin;
    public float spawnRangeMax;

    [Header("Game Design - Spawn time")]
    public float startSpawnTime;
    [Range(0.5f, 5f)] public float currentSpawnTime;
    public float spawnTimeLimit;
    public float decreasingSpawnTime;

    [Header("Game Design - Meteor Speed")]
    public float startMovementSpeed;
    [Range(2f, 16f)] public float currentMovementSpeed;
    public float limitMovementSpeed;
    public float increasingMovementSpeed;

    [Header("Game Elements")]
    public MeteorController meteor;

    [Header("Spawn time")]
    public float timeForNextSpawn = 0;
    public float currentTime = 0;

	private void FixedUpdate()
	{
        currentTime = Time.time;
        if(timeForNextSpawn <= currentTime) {
            SpawnNewMeteor();
            IncreaseDificulty();
            timeForNextSpawn = currentTime + currentSpawnTime;
        }
	}

	private void SpawnNewMeteor()
    {
        //Random a position
        float randomXPosition = Random.Range(spawnRangeMin, spawnRangeMax);
        Vector3 meteorPosition = new Vector3(randomXPosition, 
                                             transform.position.y, 
                                             transform.position.z);
        
        MeteorController newMeteor = (MeteorController)GameObject.Instantiate(meteor, meteorPosition, transform.rotation);
        newMeteor.setupMeteor(currentMovementSpeed);
    }

    private void IncreaseDificulty()
    {
        if (currentSpawnTime > spawnTimeLimit)
            currentSpawnTime -= decreasingSpawnTime;

        if (currentMovementSpeed < limitMovementSpeed)
            currentMovementSpeed += increasingMovementSpeed;
    }
}