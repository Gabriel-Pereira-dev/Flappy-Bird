using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Vector3 obstaclePosition){
        var gameManager = GameManager.Instance;
        var prefabs = gameManager.coinPrefabs;
        var prefab = prefabs[Random.Range(0,prefabs.Count)];
        Quaternion rotation = Quaternion.identity;
        float y = Random.Range(gameManager.obstacleOffsetY.x,gameManager.obstacleOffsetY.y);
        Vector3 position = new Vector3(obstaclePosition.x+ 7 * gameManager.obstacleInterval,y,obstaclePosition.z);
        Instantiate(prefab,position,rotation);
    }
}
