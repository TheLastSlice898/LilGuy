using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // target to follow
    public float speed = 0.125f; // speed of camera
    public Vector3 offset = new Vector3(0, 200, 0); // added more of an offset

    void FixedUpdate()
    {
        Vector3 CameraPosition = target.position + offset; 
        Vector3 smooth = Vector3.Lerp(transform.position, CameraPosition, speed);
        transform.position = smooth;

        transform.LookAt(target); // looks at chosen object/character
    }
}
