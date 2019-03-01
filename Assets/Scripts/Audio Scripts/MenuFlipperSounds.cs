using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFlipperSounds : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private AudioSource menuSound_1;
    [SerializeField]
    private AudioSource menuSound_2;
    [SerializeField]
    private AudioSource menuSound_3;
    [SerializeField]
    private AudioSource menuSound_4;
    private AudioSource[] sourceList;

    [SerializeField]
    private string inputName;
    
    private int randNum;

    // Start is called before the first frame update
    void Start()
    {
        sourceList = new AudioSource[4];
        sourceList[0] = menuSound_1;
        sourceList[1] = menuSound_2;
        sourceList[2] = menuSound_3;
        sourceList[3] = menuSound_4;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown(inputName))
        {
            randNum = Random.Range(0, 3);
            for (int i = 0; i < sourceList.Length; i++)
            {
                sourceList[randNum].Play();
            }
        }
    }
}
