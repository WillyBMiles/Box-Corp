using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text text;
    float timer = .75f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
            Destroy(gameObject);

        transform.position += Vector3.up * Time.deltaTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0f, 1f, timer / .75f));
    }

    public void Apply(string text, Color color)
    {
        this.text.text = text;
        this.text.color = color;
    }
}
