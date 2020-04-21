using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scene : MonoBehaviour
{
    public Camera main;
    public Camera overview;
    public Vector3 target;
    
    

    // Start is called before the first frame update
    void Start()
    {
        main.gameObject.SetActive(false);
        overview.gameObject.SetActive(true);
        //turn on the camera that will give an overview of the game
    }

    // Update is called once per frame
    void Update()
    {
       
        
        float x_position = overview.transform.position.x;
        if((target.x - x_position) < 2)
        {
           //after it overview camera get's close to the target 
           //switch to main camera
            overview.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
        }
    }
}
