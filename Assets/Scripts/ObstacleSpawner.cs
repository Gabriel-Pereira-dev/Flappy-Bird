using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval = 5f;
    private float spawnCooldown = 0f;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isGameActive){
            return;
        }
        spawnCooldown -= Time.deltaTime;
        bool canSpawn = spawnCooldown <= 0;
        if(canSpawn){
            Spawn();
        }
    }

    void Spawn(){
        spawnCooldown = spawnInterval;
        Vector3 position = spawnPoint != null ? spawnPoint.position : new Vector3(43f,0,0);
        Instantiate(prefab,position,Quaternion.identity);
    }

    
}
