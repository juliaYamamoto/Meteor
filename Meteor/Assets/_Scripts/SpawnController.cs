using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Game Design - Spawn")]
    public float spawnRangeMin = -5;
    public float spawnRangeMax = 5;
    public float spawnTime = 3;
    public float spawnTimeLimit = 1.2f;
    public float decreasingSpawnTime = 0.05f;

    [Header("Game Design - Meteor")]
    public float startMovementSpeed = 0.1f; 
    public float startRotationSpeed = 2;
    public float increasingMovementSpeed = 0.05f;
    public float increasingRotationSpeed = 0.01f;
    public float currentMovementSpeed = 0.1f;
    public float currentRotationSpeed = 2;

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
            timeForNextSpawn = currentTime + spawnTime;
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
        newMeteor.setupMeteor(currentMovementSpeed, currentRotationSpeed);
    }

    private void IncreaseDificulty()
    {
        currentMovementSpeed += increasingMovementSpeed;
        currentRotationSpeed += increasingRotationSpeed;

        if (spawnTime >= spawnTimeLimit)
        {
            spawnTime -= decreasingSpawnTime;
        }
    }
}