﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script uses keyboard events to move the object.
public class KeyboardMove : MonoBehaviour
{
    public Sprite Cathead;
    public Sprite Player;
    public float speed = 0.05f;
    public bool isCatModeActive = false;
    public float catModeDuration = 3.0f;
    Rigidbody2D rb;
    float timer;
    float catHeadStart;
    bool isAbilityUsed = false;

    // Use this for initialization
    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        catHeadStart += Time.deltaTime;

        // Amount to move in each dimension
        float dx = 0;
        float dy = 0;

        // Input.GetKey(key) returns true if that key is currently down
        // KeyCode.keyname is used for keys that don'w correspond to an ASCII char

        // Move up
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            dy = speed;
        }
        // Move down
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            dy = -speed;
        }
        // Move left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            dx = -speed;
        }
        // Move right
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            dx = speed;
        }

        // Move by that amount
        rb.position += new Vector2(dx, dy);

        if (Input.GetKeyDown("space") && !isAbilityUsed && catHeadStart > 3.0f)
        {
            GetComponent<SpriteRenderer>().sprite = Cathead;
            isAbilityUsed = true;
            isCatModeActive = true;
        }
        if (isCatModeActive)
        {
            timer += Time.deltaTime;
        }
        if (timer > catModeDuration)
        {
            isCatModeActive = false;
            GetComponent<SpriteRenderer>().sprite = Player;
        }
    }
}
