using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PlaceableObject placeableObject;

    [Space]
    public Image image;
    Button button;

    public static ToolSelector currentTool;
    

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (placeableObject != null)
            image.sprite = placeableObject.ghost;
        if (currentTool == this)
        {
            if (placeableObject != null)
                Tooltip.instance.SetText(placeableObject.description);
            else
                Tooltip.instance.SetText("<b>No tool</b><br>Right click to destroy boxes.");
        }

        button.interactable = PlacementTool.instance.objectToPlace != placeableObject;

    }

    public void OnClick()
    {
        PlacementTool.instance.SetPlaceableObject(placeableObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentTool = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentTool == this)
            currentTool = null;
    }
}
