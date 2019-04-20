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
    private int currentLives = 3;

    [Header("UI Elements")]
    public Text pointsText;
    public Text gameOverText;
    public Text tryAgainText;

    public enum GameState
    {
        Start,
        End
    } public GameState currentGameState;

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
        //Game State
        currentGameState = GameState.Start;

        //Game Variables
        currentPoints = 0;
        currentLives = 3;

        //UI Elements
        pointsText.text = "Points: 00";
        gameOverText.gameObject.SetActive(false);
        tryAgainText.gameObject.SetActive(false);

    }

    public void AddScore()
    {
        currentPoints += pointsForMeteor;
        pointsText.text = "Points: " + currentPoints;
    }

    public void LoseLife()
    {
        currentLives -= 1;
        if(currentLives == 0){
            GameOver();
        }
    }

    private void GameOver()
    {
        currentGameState = GameState.End;

        gameOverText.gameObject.SetActive(true);
        tryAgainText.gameObject.SetActive(true);
       
    }

    public void TryAgainClicked()
    {
        NewGame();
    }

}

