using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
#pragma warning disable 0649
    //[HideInInspector]
    [SerializeField]
    public int menuCheck = 0;

    [SerializeField]
    private Text menuText;
    
    private string[] menuChoices;

    [SerializeField]
    private TextMeshProUGUI leftFlipText;
    [SerializeField]
    private TextMeshProUGUI rightFlipText;
    [SerializeField]
    private TextMeshProUGUI plungerText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private string leftBumperString;
    [SerializeField]
    private string rightBumperString;

    [SerializeField]
    private Image leftArrow;
    [SerializeField]
    private Image RightArrow;

    [SerializeField]
    private float axisNum = 0;

    [SerializeField]
    private GameObject creditsMenu;

    [SerializeField]
    private HighScoreHolder scoreHold;

    // Start is called before the first frame update
    void Start()
    {
        scoreHold.SaveScore();
        menuChoices = new string[3];
        menuChoices[0] = "Play";
        menuChoices[1] = "Credits";
        menuChoices[2] = "Exit";
    }

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        scoreHold = GameObject.Find("High Score Holder").GetComponent<HighScoreHolder>();
        highScoreText.text = scoreHold.highScore.ToString();
    }
    void FixedUpdate()
    {
        StartCoroutine(ControllerCheck());
    }
    // Update is called once per frame
    void Update()
    {
        if (axisNum == 33)
        {
            leftFlipText.text = "LB";
            rightFlipText.text = "RB";
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

        if (Input.GetButtonDown(leftBumperString))
        {
            Debug.Log("left");
            creditsMenu.SetActive(false);
            menuCheck--;
        }

        if (menuCheck <= 0)
        {
            leftArrow.enabled = false;
            menuCheck = 0;
        }
        else
        {
            leftArrow.enabled = true;
        }

        if (Input.GetButtonDown(rightBumperString) && menuCheck <= 2)
        {
            Debug.Log("right");
            creditsMenu.SetActive(false);
            menuCheck++;
        }

        if (menuCheck >= (menuChoices.Length - 1))
        {
            RightArrow.enabled = false;
            menuCheck = (menuChoices.Length - 1);
        }
        else
        {
            RightArrow.enabled = true;
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
