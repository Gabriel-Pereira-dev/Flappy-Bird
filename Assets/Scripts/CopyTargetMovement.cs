using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTargetMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 distanceFromTarget = Vector3.zero;
    public bool isCopyingMovement = false;

    public Transform target;
    public Queue<PointInTime> pointsInTime;
    Rigidbody rb;

    public float targetMovementDelay = 0.1f;

    void Start()
    {
        pointsInTime = new Queue<PointInTime>();
        rb = GetComponent<Rigidbody>();
        StartCopy();
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        if(gameManager.IsGameOver()){
            StopCopy();
            return;
        }
        // else{
        //     StopCopy();
        // }
    }

    void FixedUpdate(){
        if(isCopyingMovement){
            Record();
            Invoke("Copy",targetMovementDelay);
        }
    }

    void Copy(){
        if(pointsInTime.Count > 0){
            var point = pointsInTime.Dequeue();
            transform.position = point.position + distanceFromTarget;
            transform.rotation =point.rotation;
            rb.velocity = point.velocity;
            // pointsInTime.RemoveAt(0);
        }else{
            StopCopy();
        }
    }

    void Record(){
         pointsInTime.Enqueue(new PointInTime(target.position,target.rotation,target.GetComponent<Rigidbody>().velocity));
        // pointsInTime.Insert(0,new PointInTime(target.position,target.rotation));
    }

    void StartCopy(){
        // rb.isKinematic = true;
        isCopyingMovement = true;
    }

    void StopCopy(){
        // rb.isKinematic = false;
        isCopyingMovement = false;
    }
}
