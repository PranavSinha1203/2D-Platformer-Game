﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator PlayerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(speed));

        Vector2 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

    }

 
}
