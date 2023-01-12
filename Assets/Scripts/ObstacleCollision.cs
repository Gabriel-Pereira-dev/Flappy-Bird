using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
     void OnCollisionEnter(Collision other){
        Debug.Log("Colidiu "+ other.gameObject.name);
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
