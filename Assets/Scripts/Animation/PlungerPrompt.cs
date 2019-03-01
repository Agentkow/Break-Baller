﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerPrompt : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Sprite[] aButtonSprite;

    [SerializeField]
    private Sprite[] spaceBarSprite;

    [SerializeField]
    private Image prompt;

    private float axisNum;

    // Start is called before the first frame update
    void Start()
    {
        axisNum = Input.GetJoystickNames()[0].Length;
    }

    void FixedUpdate()
    {
        axisNum = Input.GetJoystickNames()[0].Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (axisNum == 33)
        {
            prompt.sprite = aButtonSprite [(int)(Time.time)%aButtonSprite.Length];
        }
        else
        {
            prompt.sprite = spaceBarSprite[(int)(Time.time) % spaceBarSprite.Length];
        }
    }
}
