using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoxContents")]
public class BoxContents : ScriptableObject
{
    public Sprite sprite;
    [Space]
    public bool accepted;
    public Size size;
    public Weight weight;

    public bool magnetic;


}

public enum Weight
{
    Light, Medium, Heavy
}
public enum Size
{
    Small, Medium, Large
}