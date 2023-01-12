using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float height = 0f;
    // Start is called before the first frame update
    void Start()
    {
        float heightLimit = GameManager.Instance.gameHeight /2;
        height = Random.Range(-heightLimit,heightLimit);
        transform.position= new Vector3(transform.position.x,height,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isGameActive){
            return;
        }
        float speed = GameManager.Instance.obstacleSpeed;
        float movement = -1 * (speed * Time.deltaTime);

        transform.position+= new Vector3(movement,0,0);
        if(transform.position.x <= -43f){
            Destroy(gameObject);
        }

    }

 
}
