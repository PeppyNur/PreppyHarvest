using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset;    
    public Vector3 camRotation;



    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = target.rotation * Quaternion.Euler(camRotation);
    }
}