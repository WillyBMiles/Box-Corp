using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayMachine : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    float timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Box box = collision.GetComponentInParent<Box>();
        if (box != null)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = box.contents.sprite;
            timer = .25f;
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            spriteRenderer.enabled = false;
        }
    }
}
