using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    ItemPickup item;

	// Use this for initialization
	void Start () {
        item = null;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator detachFromPlayer()
    {
        if (item != null)
        {
            StartCoroutine(item.detachFromPlayer());
        }
        item = null;

        yield return null;
    }

    public IEnumerator attachToPlayer(ItemPickup newItem)
    {
        if (item != null)
        {
            StartCoroutine(item.detachFromPlayer());
        }
        item = newItem;

        itemAttachHook(newItem);

        yield return null;
    }

    public virtual void itemAttachHook(ItemPickup newItem)
    {

    }
}
