using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset; // distance between camera and target

    // Use this for initialization
    void Start()
    {
        // calculate offset value  between the target position and camera position
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        // set  camera position to be target position with calculated offset 
        transform.position = target.transform.position + offset;
    }
}
