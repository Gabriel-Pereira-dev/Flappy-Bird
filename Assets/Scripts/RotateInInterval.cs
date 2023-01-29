using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInInterval : MonoBehaviour
{
    // Start is called before the first frame update
     public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate(){
        transform.Rotate(new Vector3(0,rotationSpeed,0) * Time.deltaTime);
    }
}
