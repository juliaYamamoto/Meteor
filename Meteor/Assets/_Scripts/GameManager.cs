using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Design")]
    public int pointsForMeteor = 10;

    [Header("Game Variables")]
    private int currentPoints = 0;
    private int currentLives = 0;

    [Header("UI Elements")]
    public Text pointsText;

    public static GameManager instance = null;
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
        //Game Variables
        currentPoints = 0;
        currentLives = 0;

        //UI Elements
        pointsText.text = "Points: 00";
    }

    public void AddScore()
    {
        currentPoints += pointsForMeteor;
        pointsText.text = "Points: " + currentPoints;
    }
}