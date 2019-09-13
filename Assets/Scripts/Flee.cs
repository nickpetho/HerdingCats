using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the object away from another object with a given tag
public class Flee : MonoBehaviour
{

    Rigidbody2D rb; // Rigidbody physics component

    public string targettag = "Player";
    public float speed = 0.01f;

    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Move away from location of target object
    void Update()
    {

        // Get the target object with this tag
        GameObject targetObject = GameObject.FindWithTag(targettag);

        // If object not found, this will be null. Exit to prevent error.
        if (targetObject == null)
        {
            return;
        }

        // Get its Rigidboy component so can get its position
        Rigidbody2D targetRb = targetObject.GetComponent<Rigidbody2D>();

        // Get difference between current and target location 
        Vector2 delta = targetRb.position - rb.position;

        // Normalize to 1 
        delta.Normalize();

        // Multiply be speed
        delta = delta * speed;

        // Use this to change position
        rb.position -= delta;

    }
}
