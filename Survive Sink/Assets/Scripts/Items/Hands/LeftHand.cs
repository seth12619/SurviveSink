using UnityEngine;
using System.Collections;

public class LeftHand : Hand {

	void Update() {
		float l2  = Input.GetAxis("UseLeftHand");
		
        if (Input.GetButtonDown("DropLeftHand"))
        {
            StartCoroutine(detachFromPlayer());
        }
        if ((l2 > 0) || (Input.GetKeyDown(KeyCode.Alpha1)) )
        {
            StartCoroutine(useItem());
        }
    }

    public override void itemAttachHook(ItemPickup newItem)
    {
        StartCoroutine(newItem.attachToPlayerLeft());
    }
}
