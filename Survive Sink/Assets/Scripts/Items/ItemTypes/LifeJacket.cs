using UnityEngine;
using System.Collections;

public class LifeJacket : ItemPickup {

    public override IEnumerator use()
    {
        Debug.Log("You used a life Jacket!!!");
        yield return null;
    }
}
