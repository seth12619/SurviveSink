using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readable : ItemPickup {
    GameObject player;
    UnityChanControlScriptWithRgidBody controller;

    private bool looking = false;
    private float currTime = 0f;
    private float cancelTime = 0.25f;

    private float NORM_X_DEG_SHIFT = 126;
    private float NORM_Y_DEG_SHIFT = 190;
    private float NORM_Z_DEG_SHIFT = -111;
    private float NORM_XShift = 0.15f;
    private float NORM_YShift = -0.15f;
    private float NORM_ZShift = 0.2f;

    private float LOOK_X_DEG_SHIFT = 0;
    private float LOOK_Y_DEG_SHIFT = 90;
    private float LOOK_Z_DEG_SHIFT = 0;
    private float LOOK_XShift = 0f;
    private float LOOK_YShift = 0f;
    private float LOOK_ZShift = 0.2f;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        controller = player.GetComponent<UnityChanControlScriptWithRgidBody>();

        pickUpScale = 0.1f;
        X_DEG_Shift = NORM_X_DEG_SHIFT;
        Y_DEG_Shift = NORM_Y_DEG_SHIFT;
        Z_DEG_Shift = NORM_Z_DEG_SHIFT;
        XShift = NORM_XShift;
        YShift = NORM_YShift;
        ZShift = NORM_ZShift;
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();
        if(currTime<=cancelTime)
            currTime += Time.deltaTime;

        if (looking)
        {
            if (nextToPlayer == 0)
            {
                StartCoroutine(stopLooking());
            }
        }
	}

    public override IEnumerator use()
    {
        if (currTime > cancelTime){

            if (!looking)
            {
                currTime = 0;
                StartCoroutine(lookAt());
            }
            else
            {
                currTime = 0;
                StartCoroutine(stopLooking());
            }
        }
        yield return null;
    }

    IEnumerator lookAt()
    {
        X_DEG_Shift = LOOK_X_DEG_SHIFT;
        Y_DEG_Shift = LOOK_Y_DEG_SHIFT;
        Z_DEG_Shift = LOOK_Z_DEG_SHIFT;
        transform.position += Camera.transform.rotation * new Vector3(
            (LOOK_XShift - NORM_XShift) * nextToPlayer, LOOK_YShift - NORM_YShift, LOOK_ZShift - NORM_ZShift) * pickUpScale;
        looking = true;
        yield return null;
    }

    IEnumerator stopLooking()
    {
        X_DEG_Shift = NORM_X_DEG_SHIFT;
        Y_DEG_Shift = NORM_Y_DEG_SHIFT;
        Z_DEG_Shift = NORM_Z_DEG_SHIFT;
        transform.position += Camera.transform.rotation * new Vector3(
            (NORM_XShift - LOOK_XShift) * nextToPlayer, NORM_YShift - LOOK_YShift, NORM_ZShift - LOOK_ZShift) * pickUpScale;
        looking = false;
        yield return null;
    }
}
