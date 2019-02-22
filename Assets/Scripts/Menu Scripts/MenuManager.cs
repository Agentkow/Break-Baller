using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
#pragma warning disable 0649
    [HideInInspector]
    public int menuCheck = 0;

    [SerializeField]
    private Text menuText;
    
    private string[] menuChoices;

    [SerializeField]
    private Text leftFlipText;
    [SerializeField]
    private Text rightFlipText;
    [SerializeField]
    private Text plungerText;

    private float axisNum;

    // Start is called before the first frame update
    void Start()
    {
        axisNum = Input.GetJoystickNames()[0].Length;
        menuChoices = new string[3];
        menuChoices[0] = "Play";
        menuChoices[1] = "Credits";
        menuChoices[2] = "Exit";
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
            leftFlipText.text = "LT";
            rightFlipText.text = "RT";
            plungerText.text = "A Button";
        }
        else
        {
            leftFlipText.text = "Q";
            rightFlipText.text = "E";
            plungerText.text = "Space";
        }

        MenuChoiceSwap();
    }

    private void MenuChoiceSwap()
    {
        for (int i = 0; i < menuChoices.Length; i++)
        {
            menuText.text = menuChoices[menuCheck];
        }

        if (Input.GetButtonDown("Left Bumper"))
        {
            menuCheck--;
        }

        if (menuCheck <= 0)
        {
            menuCheck = 0;
        }

        if (Input.GetButtonDown("Right Bumper") && menuCheck <= 2)
        {
            menuCheck++;
        }
        if (menuCheck >= (menuChoices.Length - 1))
        {
            menuCheck = (menuChoices.Length - 1);
        }
    }
}
