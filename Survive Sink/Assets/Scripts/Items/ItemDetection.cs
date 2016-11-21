using UnityEngine;
using System.Collections;

public class ItemDetection : Detection {
    LeftHand leftHand;
    RightHand rightHand;
    RaycastHit hitMe;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        leftHand = player.GetComponent<LeftHand>();
        rightHand = player.GetComponent<RightHand>();
    }

    public override void doAction(RaycastHit hit)
    {
        hitMe = hit;
        if (Input.GetButtonDown("LeftHand"))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(leftHand.attachToPlayer(itemPickedUp));

        } else if (Input.GetButtonDown("RightHand"))
        {
            GameObject item = hit.transform.gameObject;

            ItemPickup itemPickedUp = item.GetComponent<ItemPickup>();

            StartCoroutine(rightHand.attachToPlayer(itemPickedUp));

        }
    }
}
