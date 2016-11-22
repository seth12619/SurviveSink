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

        pickUpScale = 0.1f;
        X_DEG_Shift = -10;
        Y_DEG_Shift = 160;
        Z_DEG_Shift = -30;
        XShift = 0.3f;
        YShift = -0.1f;
        ZShift = 0.2f;
    }

    public override IEnumerator use()
    {
        Debug.Log(Det.hitMe.collider.tag);
        if(Det.hitMe.collider.tag == tagFurn)
        {
            GameObject furn = Det.hitMe.transform.gameObject;

            Destroy(furn);
        }
        yield return null;
    }
}
