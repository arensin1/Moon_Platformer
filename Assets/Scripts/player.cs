using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public characterController controller;
    public float runningSpeed = 40f;
    float hori = 0f;
    bool jump = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getting user input for jump and horizontal movement
        hori = Input.GetAxisRaw("Horizontal") * runningSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //using function to move player
        controller.Move(hori * Time.fixedDeltaTime, jump);
        jump = false;
    }

}
