using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(x, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
