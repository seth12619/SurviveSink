using UnityEngine;
using System.Collections;

public class LeftHand : Hand {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(detachFromPlayer());
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(useItem());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerLeft());
    }
}
