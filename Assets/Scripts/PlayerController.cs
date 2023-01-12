using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10f;
    public float jumpInterval = 0.5f;
    public float jumpCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isGameActive){
            return;
        }
        jumpCooldown -= Time.deltaTime;
        
        bool canJump = jumpCooldown <= 0;
        if(canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput){
                Jump();
            }
        }
        
        
    }

    void Jump(){
        jumpCooldown = jumpInterval;

        this.thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
    }
}
