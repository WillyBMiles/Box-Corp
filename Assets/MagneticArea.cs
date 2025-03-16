using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticArea : MonoBehaviour
{
    public float force;

    public Vector2 direction;

    private void OnTriggerStay2D(Collider2D other)
    {
        Box box = other.GetComponentInParent<Box>();
        if (box == null || !box.contents.magnetic)
            return;
        Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
        rb.AddForceAtPosition(force * direction, box.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
