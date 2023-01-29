using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get;private set;}
    public List<GameObject> obstaclePrefabs;
    public float obstacleSpeed = 10f;
    public float obstacleInterval = 1f;
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    public float obstacleOffsetX = 0f;
    public List<GameObject> coinPrefabs;

    
    [HideInInspector]
    public int score = 0;
    public GameObject player;
    private bool isGameOver;
    public float restartDelay = 5.0f;
    public float gameHeight = 8.8f;
    public float gameWidth = 31f;

    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    void OnEnable(){
        Coin.OnCoinCollected+= AddScore;
        PlayerController.OnPlayerScored += AddScore;
    }

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    public bool IsGameActive(){
        return !isGameOver;
    }

    public bool IsGameOver(){
        return isGameOver;
    }

    public void GameOver(){
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void AddScore(){
        score++;
        if(scoreText != null){
            scoreText.text = "Score\n"+ score;
        }
    }
}
