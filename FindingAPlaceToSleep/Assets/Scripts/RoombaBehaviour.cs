using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBehaviour : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public int turnTime = 5; // how long it takes to turn
    public int turnAmount = 90; // how far to turn

    private bool turning;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!turning && (col.gameObject.tag == "Walls" || col.gameObject.tag == "Movable" || col.gameObject.tag == "Bed"))
        {
            Debug.Log(name + " collided with " + col.gameObject.name);

            turning = true;
            rb.velocity = Vector3.zero;

            // temporarily gain physics to avoid passing through objects
            GetComponent<BoxCollider>().isTrigger = false;

            // complete an input-amount turn over input-amount of time
            StartCoroutine(RotateMe(Vector3.up * turnAmount, turnTime));
        }
    }

    // interpolate rotations for a turn over time, then remove temporary physics 
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        turning = false;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void FixedUpdate()
    {
        if (!turning)
        {
            // continuous movement except when turning 
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
