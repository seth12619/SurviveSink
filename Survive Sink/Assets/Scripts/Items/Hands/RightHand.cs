using UnityEngine;
using System.Collections;

public class RightHand : Hand {

    void Update()
    {
		float r2 = Input.GetAxis("UseRightHand");
        if (Input.GetButtonDown("DropRightHand"))
        {
            StartCoroutine(detachFromPlayer());
        }
        if ((r2<0) || (Input.GetKeyDown(KeyCode.Alpha2)) )
        {
            StartCoroutine(useItem());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerRight());
    }
}
