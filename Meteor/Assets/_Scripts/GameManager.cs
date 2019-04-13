using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int currentPoints = 0;
    public int currentLives = 0;

    public int pointsForMeteor = 10;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        NewGame();
    }

    private void NewGame()
    {
        currentPoints = 0;
        currentLives = 0;
    }

    public void AddScore()
    {
        currentPoints += pointsForMeteor;
    }
}