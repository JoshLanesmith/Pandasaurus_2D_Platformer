using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ButterflyMovement : MonoBehaviour
{

    private float pos1 = 0f;
    private float pos2 = 0f;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Flips butterfly direction depending on movement
        pos1 = sprite.transform.position.x;
        if (pos1 > pos2)
        {
            sprite.flipX = true;
        }
        else if (pos2 > pos1)
        {
            sprite.flipX = false;
        }
        pos2 = sprite.transform.position.x;
    }
}
