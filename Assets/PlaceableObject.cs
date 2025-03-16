using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public static List<GameObject> placers = new();
    public List<PlaceableObject> variants = new();
    public Sprite ghost;

    public int cost;
    [TextArea(5,20)]
    public string description;

    public bool cantBeDeleted;

    // Start is called before the first frame update
    void Start()
    {
        placers.Add(gameObject);
    }
    private void OnDestroy()
    {
        placers.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlaceableObject GetNextObject(PlaceableObject currentObject)
    {
        if (variants.Count == 0)
            return this;
        if (currentObject == this)
        {
            return variants[0];
        }
        int index = variants.IndexOf(currentObject);
        if (variants.Count > index + 1)
        {
            return variants[index + 1];
        }
        return this;
    }

    public void ShowGhost(Vector3 point, SpriteRenderer sprite)
    {
        sprite.transform.position = point;
        sprite.sprite = ghost;
    }
}
