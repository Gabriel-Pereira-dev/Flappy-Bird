using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float spawnCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameOver()){
            return;
        }
        spawnCooldown -= Time.deltaTime;
        bool canSpawn = spawnCooldown <= 0f;
        if(canSpawn){
            Spawn();
        }
    }

    void Spawn(){
        var gameManager = GameManager.Instance;
        var prefabs = gameManager.obstaclePrefabs;
        var prefab = prefabs[Random.Range(0,prefabs.Count)];
        spawnCooldown = gameManager.obstacleInterval;
        float x = gameManager.obstacleOffsetX;
        float y = Random.Range(gameManager.obstacleOffsetY.x,gameManager.obstacleOffsetY.y);
        Vector3 position = new Vector3(x,y,0);
        var rotation = prefab.transform.rotation;
        Instantiate(prefab,position,rotation);
    }

    
}
