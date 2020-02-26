using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public characterController controller;
    public float runningSpeed = 40f;
    float hori = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxisRaw("Horizontal") * runningSpeed;
    }

    void FixedUpdate()
    {
        controller.Move(hori * Time.fixedDeltaTime, false);
    }
}
