using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float scrollSpeed;
    public float zoomSpeed;

    [Space]
    public float upperBoundary;
    public float lowerBoundary;
    public float rightBoundary;
    public float leftBoundary;

    public float minZoom;
    public float maxZoom;
    [Space]
    public float cameraExtentMult;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float zoomAmount = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) ( scrollSpeed * Time.deltaTime * (Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical")));
        Vector3 pos = new();

        pos.y = Mathf.Clamp(transform.position.y, lowerBoundary + Camera.main.orthographicSize * cameraExtentMult, upperBoundary - Camera.main.orthographicSize * cameraExtentMult);
        pos.x = Mathf.Clamp(transform.position.x, leftBoundary + Camera.main.orthographicSize * cameraExtentMult, rightBoundary - Camera.main.orthographicSize * cameraExtentMult);
        transform.position = new Vector3(pos.x, pos.y, -10);
        if (Input.GetKey(KeyCode.Q))
        {
            zoomAmount += zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            zoomAmount -= zoomSpeed * Time.deltaTime;
        }
        zoomAmount += Input.mouseScrollDelta.y * zoomSpeed;
        zoomAmount = Mathf.Clamp(zoomAmount, minZoom, maxZoom);

        Camera.main.orthographicSize = zoomAmount;
    }
}
