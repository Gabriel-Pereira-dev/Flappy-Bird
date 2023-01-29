using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class GravityScale3D : MonoBehaviour
    {
 
    public float gravityScale = 1.0f;
 
    Rigidbody m_rb;
 
    void OnEnable ()
        {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
        }
 
    void FixedUpdate ()
        {
        m_rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
        }
    }