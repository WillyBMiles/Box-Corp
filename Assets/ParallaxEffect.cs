using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public float parallax = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 lastCameraPosition;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = Camera.main.transform.position - lastCameraPosition;

        transform.position += offset * parallax;

        lastCameraPosition = Camera.main.transform.position;
    }
}
