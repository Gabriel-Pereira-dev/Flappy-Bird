using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get;private set;}
    public float obstacleSpeed = 10f;
    public int score = 0;
    public GameObject player;
    [HideInInspector]
    public bool isGameActive {get; private set;} = true;
    public float restartDelay = 5.0f;
    public float gameHeight = 8.8f;
    public float gameWidth = 31f;

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    public void GameOver(){
        if(!isGameActive){
            return;
        }
        isGameActive = false;

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
