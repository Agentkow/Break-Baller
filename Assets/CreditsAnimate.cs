using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimate : MonoBehaviour
{

    private MenuManager manager;
    
    private Animator creditBlock;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Menu Manager").GetComponent<MenuManager>();
        creditBlock = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.menuCheck ==1)
        {
            creditBlock.SetBool("Credits", true);
        }
        else
        {
            creditBlock.SetBool("Credits", false);
        }
    }
}
