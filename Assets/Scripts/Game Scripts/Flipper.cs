using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField]
    private float restPos = 0f;
    [SerializeField]
    private float pressedPos = 45f;
    [SerializeField]
    private float hitStrength = 100000f;
    private float flipDamp = 150f;

    private HingeJoint hinge;

    [SerializeField]
    private string inputName;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipDamp;

        if (Input.GetButton(inputName))
        {
            spring.targetPosition = pressedPos;
        }
        else
        {
            spring.targetPosition = restPos;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
