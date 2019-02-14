using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform startTransmform;
    private Transform form;

    [SerializeField]
    private float speed=100f;

    // Start is called before the first frame update
    void Start()
    {
        form = this.transform;
        startTransmform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        MoveBar(new Vector2(Input.GetAxis("Horizontal"), 0));
        
    }

    void MoveBar(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
