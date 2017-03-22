using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : ItemPickup {
    public GameObject foam;
    public bool firing = false;
    public float timePassed = 0f;
    public float timeToFire = 0.25f;
    public float ammo = 2000;

    private Vector3 foamDisplacement;                                                                                     

	// Use this for initialization
	public override void Start () {
        base.Start();
        foamDisplacement = new Vector3(0f, 0f, 0.1f);
        X_DEG_Shift = 0;
        Y_DEG_Shift = 30;
        Z_DEG_Shift = 45;

        XShift = 0.2f;
        YShift = -0.2f;
        ZShift = 0.25f;

        pickUpScale = 0.05f;
	}

    public override void Update()
    {
        base.Update();
        if (firing)
        {
            if (nextToPlayer == 0)
            {
                firing = false;
            }
            else {
                timePassed += Time.deltaTime;
                if (ammo > 0 && timePassed > timeToFire)
                {
                    ammo--;
                    timePassed = 0;
                    Instantiate(foam, transform.position + transform.rotation * foamDisplacement, transform.rotation);
                }
            }
        }
    }

    public override IEnumerator use()
    {
        firing = !firing;
        yield return null;
    }
}
