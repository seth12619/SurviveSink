using UnityEngine;
using System.Collections;

public class FireAx : ItemPickup {
    GameObject player;
    Detection Det;

    private string tagFurn = "Furniture";

    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        Det = player.GetComponent<ItemDetection>();
    }

    public override IEnumerator use()
    {
        if(Det.hitMe.collider.tag == tagFurn)
        {
            GameObject furn = Det.hitMe.transform.gameObject;

            Destroy(furn);
        }
        yield return null;
    }
}
