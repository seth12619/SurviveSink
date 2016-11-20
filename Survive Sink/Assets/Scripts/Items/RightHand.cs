using UnityEngine;
using System.Collections;

public class RightHand : Hand {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(detachFromPlayer());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerRight());
    }
}
