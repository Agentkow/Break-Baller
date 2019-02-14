using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [HideInInspector]
    public int menuCheck = 0;

    [SerializeField]
    private Text menuText;

    private string[] menuChoices;

    // Start is called before the first frame update
    void Start()
    {
        menuChoices = new string[4];
        menuChoices[0] = "Play";
        menuChoices[1] = "Options";
        menuChoices[2] = "Credits";
        menuChoices[3] = "Exit";
    }

    // Update is called once per frame
    void Update()
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
        if (menuCheck >= (menuChoices.Length-1))
        {
            menuCheck = (menuChoices.Length - 1);
        }
    }
}
