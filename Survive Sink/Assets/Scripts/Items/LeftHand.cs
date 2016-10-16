using UnityEngine;
using System.Collections;

public class LeftHand : Hand {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(detachFromPlayer());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerLeft());
    }
}
