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

    public IEnumerator useItem()
    {
        if (item != null)
        {
            StartCoroutine(item.GetComponent<ItemPickup>().use());
        }
        yield return null;
    }

    public IEnumerator detachFromPlayer()
    {
        if (item != null)
        {
            GameObject ship = GameObject.Find("Ship");
            StartCoroutine(item.detachFromPlayer(ship.transform.rotation));
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
