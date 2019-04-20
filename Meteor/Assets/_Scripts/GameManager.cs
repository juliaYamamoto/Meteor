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
    private int highScore = 0;

    [Header("UI Elements")]
    public Text pointsText;
    public Text highScoreText;
    public Text gameOverText;
    public Text tryAgainText;

    [Header("UI Elements - Lifes")]
    public Image oneLifeImage;
    public Image twoLifesImage;
    public Image threeLifesImage;

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

        oneLifeImage.gameObject.SetActive(true);
        twoLifesImage.gameObject.SetActive(true);
        threeLifesImage.gameObject.SetActive(true);
    }

    public void AddScore()
    {
        currentPoints += pointsForMeteor;
        pointsText.text = "Points: " + currentPoints;
    }

    public void LoseLife()
    {
        currentLives -= 1;

        if(currentLives == 2){
            threeLifesImage.gameObject.SetActive(false);
        } else if (currentLives == 1) {
            twoLifesImage.gameObject.SetActive(false);
        } else if (currentLives == 0)
        {
            oneLifeImage.gameObject.SetActive(false);
            GameOver();
        }

    }

    private void GameOver()
    {
        currentGameState = GameState.End;

        gameOverText.gameObject.SetActive(true);
        tryAgainText.gameObject.SetActive(true);

        if(highScore < currentPoints){
            highScore = currentPoints;
            highScoreText.text = "High Score: " + highScore;
        }
       
    }

    public void TryAgainClicked()
    {
        NewGame();
    }

}