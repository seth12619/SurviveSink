using UnityEngine;
using System.Collections;

public class LeftHand : Hand {

    {
        if (Input.GetButtonDown("DropLeftHand"))
        {
            StartCoroutine(detachFromPlayer());
        }
        if (l2 > 0)
        {
            StartCoroutine(useItem());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerLeft());
    }
}
