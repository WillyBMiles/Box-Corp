using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableObjects : MonoBehaviour
{
    public static AvailableObjects instance;

    public List<BoxContents> allBoxContents = new();
    List<BoxContents> accepters = new();
    List<BoxContents> rejectors = new();

    public List<BoxContents> currentContents = new();

    public float multiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartingContents();
    }
    void StartingContents()
    {
        accepters.Clear();
        rejectors.Clear();
        currentContents.Clear();
        foreach (BoxContents bc in allBoxContents)
        {
            if (bc.accepted)
            {
                accepters.Add(bc);
            }
            else
                rejectors.Add(bc);
        }
        currentContents.Add(PopAcceptor());
        currentContents.Add(PopRejector());
        Clipboard.instance.Recalculate();
    }

    BoxContents PopAcceptor()
    {
        if (accepters.Count == 0)
            return null;
        BoxContents bc = accepters[Random.Range(0, accepters.Count)];
        accepters.Remove(bc);
        return bc;
    }
    BoxContents PopRejector()
    {
        if (rejectors.Count == 0)
            return null;
        BoxContents bc = rejectors[Random.Range(0, rejectors.Count)];
        rejectors.Remove(bc);
        return bc;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewObject()
    {
        if (accepters.Count == 0 && rejectors.Count == 0)
            return;
        if (accepters.Count > rejectors.Count)
        {
            currentContents.Add(PopAcceptor());
        }
        else if (rejectors.Count > accepters.Count)
        {
            currentContents.Add(PopRejector());
        }
        else 
        {
            if (Random.value < .5f)
            {
                currentContents.Add(PopAcceptor());
            }
            else
                currentContents.Add(PopRejector());
        }
        multiplier *= 1.25f;
        Clipboard.instance.Recalculate();
    }
}
