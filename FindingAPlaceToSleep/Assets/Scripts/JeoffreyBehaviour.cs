using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JeoffreyBehaviour : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public int turnTime = 5; // how long it takes to turn
    public int turnAmount = 90; // how far to turn
    public GameObject bed;

    private bool stop;
    private Rigidbody rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!stop && (col.gameObject.tag == "Kinematic" || col.gameObject.tag == "Dynamic"))
        {
            stop = true;
            rb.velocity = Vector3.zero;
            anim.SetBool("isTurning", true);

            // temporarily gain physics to avoid passing through objects
            GetComponent<BoxCollider>().isTrigger = false;

            // complete an input-amount turn over input-amount of time
            StartCoroutine(RotateMe(Vector3.up * turnAmount, turnTime));
        }
        else if (col.gameObject.tag == "Bed")
        {
            stop = true;
            rb.velocity = Vector3.zero;

            // rotate and translate to match the bed orientation
            transform.eulerAngles = new Vector3(30.0f, -90.0f, 0.0f);

            anim.SetBool("victory", true);
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
        stop = false;
        anim.SetBool("isTurning", false);
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void FixedUpdate()
    {
        if (!stop)
        {
            // continuous movement except when turning 
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
