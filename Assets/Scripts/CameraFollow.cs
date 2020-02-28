using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCam = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCam,
        smoothing * Time.deltaTime);
    }
}
