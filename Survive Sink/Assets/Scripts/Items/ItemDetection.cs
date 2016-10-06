using UnityEngine;
using System.Collections;

public class ItemDetection : Detection {

    public override void doAction(RaycastHit hit)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(itemPickedUp.attachToPlayerLeft());
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(itemPickedUp.attachToPlayerRight());
        }
    }
}
