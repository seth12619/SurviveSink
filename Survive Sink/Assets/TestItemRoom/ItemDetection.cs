using UnityEngine;
using System.Collections;

public class ItemDetection : Detection {

    public override void doAction(RaycastHit hit)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(itemPickedUp.attachToPlayerLeft());
        } else if (Input.GetKey(KeyCode.R))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(itemPickedUp.attachToPlayerRight());
        }
    }
}
