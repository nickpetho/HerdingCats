using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdedHome : MonoBehaviour
{

    Rigidbody2D rb; // Rigidbody physics component

    public float closeenough = Mathf.Abs(1.0f);
    public string targettag = "Finish";
    Vector2 targetPosition = new Vector2 (0,0);

    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the target object with this tag
        GameObject targetObject = GameObject.FindWithTag(targettag);

        if (transform.position targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
        }

    }
}
