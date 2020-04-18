using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_overview : MonoBehaviour
{
    public float smoothing = 8f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 position;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!animator.GetBool("1stDialog"))
        {
            transform.position = Vector3.SmoothDamp(this.transform.position,position ,
        ref velocity, smoothing);
        }
        
    }
}
