using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Update is called once per frame
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
