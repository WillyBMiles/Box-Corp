using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOffZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Box box = collision.GetComponentInParent<Box>();
        if (box == null)
            return;
        if (box.contents.accepted)
        {
            GlobalVars.instance.GainMoney((int) (AvailableObjects.instance.multiplier + Random.Range(0f,.95f)), box.transform.position);
            GlobalVars.instance.deliveries++;
        }
        else
        {
            Debug.Log("You suck!");
            GlobalVars.instance.CostMoney(1000, box.transform.position);
            GlobalVars.instance.failures++;
        }

        Destroy(box.gameObject);
        
    }
}
