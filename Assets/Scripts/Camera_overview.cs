using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_overview : MonoBehaviour
{
    public float smoothing = 8f;
    private Vector3 velocity = Vector3.zero; // setting velocity to 0.
    public Vector3 position;
    public Animator animator;
    public DialogueManager manager;

    

    // Update is called once per frame
    void LateUpdate()
    {
        if(animator.GetBool("EndofConvo"))
        {
            transform.position = Vector3.SmoothDamp(this.transform.position,position ,
        ref velocity, smoothing);
        //at the end dialog animagion camera will move
        }
        
    }
}
