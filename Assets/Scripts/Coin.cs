using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour,ICollectible
{
    public static event Action OnCoinCollected;
    public void Collect()
    {
        OnCoinCollected.Invoke();
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        var gameManager = GameManager.Instance;
        if(gameManager.IsGameOver()){
            return;
        }
        float speed = gameManager.obstacleSpeed;
        float movement = speed * Time.fixedDeltaTime;

        transform.position-= new Vector3(movement,0,0);
        if(transform.position.x <= -gameManager.obstacleOffsetX){
            Destroy(gameObject);
        }

    }
}
