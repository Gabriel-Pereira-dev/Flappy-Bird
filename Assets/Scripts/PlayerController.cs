using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        jumpCooldown -= Time.deltaTime;
        
        bool canJump = jumpCooldown <= 0 && gameManager.IsGameActive();
        if(canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput){
                Jump();
            }
        }
        
        thisRigidbody.useGravity = gameManager.IsGameActive();
    }

    void Jump(){
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other){
        var gameManager = GameManager.Instance;
        bool isSensor = other.gameObject.CompareTag("Sensor");
        if(isSensor){
            gameManager.score++;
            Debug.Log("Score: " +  gameManager.score);
        }
    }
}
