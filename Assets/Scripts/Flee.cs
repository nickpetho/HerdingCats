using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the object away from another object with a given tag
public class Flee : MonoBehaviour
{

    Rigidbody2D rb; // Rigidbody physics component

    public string targettag = "Player";
    public float speed = 0.01f;
    public bool isCaught = false;

    KeyboardMove playerScript;

    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindWithTag(targettag).GetComponent<KeyboardMove>();
    }

    // Move away from location of target object
    void Update()
    {

        if (!isCaught)
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
            if (playerScript.isCatModeActive)
            {
                rb.position += delta;

            }
            else
            {
                rb.position -= delta;
            }

            if (Mathf.Abs(transform.position.x) < 1 && Mathf.Abs(transform.position.y) < 1)
            {
                isCaught = true;
            }
        }
    }
}
