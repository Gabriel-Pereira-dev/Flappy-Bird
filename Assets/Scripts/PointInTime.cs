using UnityEngine;
using System;

[Serializable]
public class PointInTime
{
    // Start is called before the first frame update
    public Quaternion rotation {get;set;}
    public Vector3 position {get;set;}
    public Vector3 velocity {get;set;}

    public PointInTime(Vector3 _position,Quaternion _rotation,Vector3 _velocity){
        position = _position;
        rotation = _rotation;
        velocity = _velocity;
    }
}
