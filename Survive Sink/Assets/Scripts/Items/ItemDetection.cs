using UnityEngine;
using System.Collections;

public class ItemDetection : Detection {
    LeftHand leftHand;
    RightHand rightHand;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        leftHand = player.GetComponent<LeftHand>();
        rightHand = player.GetComponent<RightHand>();
    }

    public override void doAction(RaycastHit hit)
    {
        hitMe = hit;
        GameObject item = hit.transform.gameObject;

        if (Input.GetButtonDown("LeftHand"))
        {
            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(leftHand.attachToPlayer(itemPickedUp));

        } else if (Input.GetButtonDown("RightHand"))
        {
            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(rightHand.attachToPlayer(itemPickedUp));
        }
    }
}
