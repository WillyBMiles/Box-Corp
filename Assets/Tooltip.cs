using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    public Text text;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    int timer = 0;
    // Update is called once per frame
    void Update()
    {

        timer--;
        if (timer <= 0)
        {
            parent.SetActive(false);
        }
    }

    public void SetText(string s)
    {
        text.text = s;
        timer = 2;
        parent.SetActive(true);
    }
}
