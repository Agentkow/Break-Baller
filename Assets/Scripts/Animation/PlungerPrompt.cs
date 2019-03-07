using System.Collections;
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

    private float axisNum =0;

    

   void FixedUpdate()
    {
        StartCoroutine(ControllerCheck());
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
    IEnumerator ControllerCheck()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (!string.IsNullOrEmpty(Input.GetJoystickNames()[i]))
            {
                axisNum = Input.GetJoystickNames()[0].Length;
            }
            else
            {
                axisNum = 0;
            }
        }
    }
}
