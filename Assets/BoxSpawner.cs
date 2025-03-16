using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box;
    public float timeBetween;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Clipboard.instance.PausedProduction)
            return;
        if (time < 0)
        {
            Instantiate(box, transform.position, transform.rotation);
            time = timeBetween;
        }
        time -= Time.deltaTime;
    }
}
