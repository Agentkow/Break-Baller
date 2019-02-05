using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plunger : MonoBehaviour
{
    [SerializeField]
    private float power;
    private float minPower = 0f;
    [SerializeField]
    private float maxPower = 100f;
    [SerializeField]
    private Slider powerSlider;
    private bool ballReady;

    List<Rigidbody> ballList;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;
        if (ballList.Count>0)
        {
            ballReady = true;
            if (Input.GetButton("Jump"))
            {
                if (power<=maxPower)
                {
                    power += 20 * Time.deltaTime;
                }
            }
            if (Input.GetButtonUp("Jump"))
            {
                foreach(Rigidbody r in ballList)
                {
                    r.AddForce(power*Vector3.forward*20);
                }
            }
        }
        else
        {
            ballReady = false;
            power = minPower;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = minPower;
        }
    }
}
