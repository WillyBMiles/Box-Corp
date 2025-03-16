using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public ParticleSystem destruction;
    public BoxContents contents;

    public List<SpriteRenderer> sizeRenderers;
    public List<Collider2D> collider2Ds;
    Rigidbody2D rb;

    public List<int> layers = new();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetContents(AvailableObjects.instance.currentContents[Random.Range(0, AvailableObjects.instance.currentContents.Count)]);
    }

    void SetContents(BoxContents contents)
    {
        this.contents = contents;

        sizeRenderers[(int)contents.size].enabled = true;
        collider2Ds[(int)contents.size].enabled = true;
        rb.mass = 1 + (int)contents.weight * .2f;

        gameObject.layer = layers[(int)contents.size];

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < 6)
        {
            DestroyThis();
        }
        
    }
    public bool destroying = false;
    public void DestroyThis()
    {
        if (destroying)
            return;
        destroying = true;
        destruction.Play();
        Invoke(nameof(ActualDestroy), .5f);
        Invoke(nameof(Disappear), .2f);
        GlobalVars.instance.incinerations++;
    }

    void Disappear()
    {
        foreach (SpriteRenderer sr in sizeRenderers)
        {
            sr.enabled = false;
        }
    }
    void ActualDestroy()
    {
        Destroy(gameObject);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            DestroyThis();
        }
    }
}
