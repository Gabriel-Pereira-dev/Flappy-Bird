using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour

{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0f;

    private bool canJump = false;

    public static event Action OnPlayerScored;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameOver()){
            bool isPressingEnter = Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter);
            if(isPressingEnter){
                GameManager.Instance.RestartGame();
            }
           return;
       }

        jumpCooldown -= Time.deltaTime;
        var gameManager = GameManager.Instance;
        canJump = jumpCooldown <= 0 && gameManager.IsGameActive();
        
        
        // thisRigidbody.useGravity = gameManager.IsGameActive();
    }

    void FixedUpdate(){
        if(canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput){
                Jump();
            }
        }
    }

    void Jump(){
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
    }

    void CreateChild(){

    }

    void OnTriggerEnter(Collider other){
        var gameManager = GameManager.Instance;
        bool isSensor = other.gameObject.CompareTag("Sensor");
        if(isSensor){
            OnPlayerScored.Invoke();
            Debug.Log("Score: " +  gameManager.score);
        }
    }
}
