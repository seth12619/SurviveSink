using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : ItemPickup {
    public GameObject foam;
    public bool firing = false;                                                                                     

	// Use this for initialization
	public override void Start () {
        base.Start();
        X_DEG_Shift = 126;
        Y_DEG_Shift = 220;
        Z_DEG_Shift = -131;

        XShift = 0.2f;
        YShift = -0.1f;
        ZShift = 0.2f;

        pickUpScale = 0.05f;
	}

    public override void Update()
    {
        base.Update();
    }

    public override IEnumerator use()
    {
        yield return null;
    }
}
