using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTool : MonoBehaviour
{
    public PlaceableObject objectToPlace;
    PlaceableObject actualObject;
    public SpriteRenderer ghost;

    public static PlacementTool instance;

    // Start is called before the first frame update
    void Start()
    {
        actualObject = objectToPlace;
        instance = this;
    }

    float rotation = 0f;
    // Update is called once per frame
    void Update()
    {
        if (actualObject == null || objectToPlace == null || Clipboard.instance.parent.activeInHierarchy || GlobalVars.instance.overUI)
        {
            ghost.enabled = false;
            return;
        }


        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0);
        if (Input.GetMouseButton(0) && CanPlace(pos, actualObject) && !GlobalVars.instance.overUI)
        {
            Quaternion.Euler(new Vector3(0f, 0f, rotation));
            Instantiate(actualObject.gameObject, pos, Quaternion.Euler(new Vector3(0f, 0f, rotation)));

            GlobalVars.instance.CostMoney(actualObject.cost, pos);
        }
        else
        {
            actualObject.ShowGhost(pos, ghost);
            ghost.enabled = true;
            if (CanPlace(pos, actualObject))
            {
                ghost.color = new Color(1f, 1f, 1f, .5f);
            }
            else
            {
                ghost.color = new Color(1f, 0f, 0f, .5f);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject go = GetPlacer(pos);
            if (go != null)
            {
                PlaceableObject po = go.GetComponent<PlaceableObject>();
                if (po.cantBeDeleted)
                {
                    return;
                }
                GlobalVars.instance.GainMoney((int)(po.cost * .8f), go.transform.position);
                Destroy(go);
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            actualObject = objectToPlace.GetNextObject(actualObject);
        }
    }

    bool CanPlace(Vector3 point, PlaceableObject placeableObject)
    {
        if (placeableObject.cost > GlobalVars.instance.money)
        {
            return false;
        }
        return GetPlacer(point) == null;
    }
    GameObject GetPlacer(Vector3 point)
    {
        foreach (GameObject p in PlaceableObject.placers)
        {
            if (Vector2.Distance(point, p.transform.position) < .1f)
            {
                return p;
            }
        }
        return null;
    }


    public void SetPlaceableObject(PlaceableObject placeableObject)
    {
        objectToPlace = placeableObject;
        actualObject = placeableObject;
    }
}
