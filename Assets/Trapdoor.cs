using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;
    public Collider2D myCollider;

    public List<Weight> weightsDropped = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        Box box = collision.GetComponentInParent<Box>();
        if (box !=null && weightsDropped.Contains(box.contents.weight))
        {
            timer = .4f;
            Open();
        }
    }

    float timer = 0f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Close();
        }
    }

    void Open()
    {
        spriteRenderer.sprite = openSprite;
        myCollider.enabled = false;
    }
    void Close()
    {
        spriteRenderer.sprite = closedSprite;
        myCollider.enabled = true;
    }
}
