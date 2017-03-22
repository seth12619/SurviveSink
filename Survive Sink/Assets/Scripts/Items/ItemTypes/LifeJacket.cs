using UnityEngine;
using System.Collections;

public class LifeJacket : ItemPickup {
    GameObject player;
    UnityChanControlScriptWithRgidBody controller;

    private static float JacketSlowDown = 0.5f;
    private bool slowingDown = false;
    private float finishTime = 8f;
    private float currTime = 0f;
    private float cancelTime = 2f;

    private string ACTION = "Putting on Life Jacket";

    private float movement = -0.025f;

    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        controller = player.GetComponent<UnityChanControlScriptWithRgidBody>();

        pickUpScale = 0.1f;
        X_DEG_Shift = 126;
        Y_DEG_Shift = 190;
        Z_DEG_Shift = -111;
        XShift = 0.15f;
        YShift = -0.15f;
        ZShift = 0.2f;
    }

    public override void Update()
    {
        base.Update();
        if (slowingDown)
        {
            currTime += Time.deltaTime;
            if (nextToPlayer == 0)
            {
                StartCoroutine(stopTrying());
            }
            else if (nextToPlayer == 1)
            {
                StartCoroutine(aT.rightHandAction(ACTION, finishTime, currTime));
            }
            else
            {
                StartCoroutine(aT.leftHandAction(ACTION, finishTime, currTime));
            }

            if (currTime > finishTime)
            {
                StartCoroutine(stopTrying());
                Hand temporary;
                if (nextToPlayer == 1)
                {
                    temporary = player.GetComponent<RightHand>();
                }
                else
                {
                    temporary = player.GetComponent<LeftHand>();
                }
                StartCoroutine(temporary.detachFromPlayer());
                StartCoroutine(mainTracker.addLifeJacket());
                //StartCoroutine(mainTracker.useStamina(40));
                //transform.position = GameObject.Find("Tracker").transform.position;
                StartCoroutine(destroyMe());
            }
        }
    }

    public override IEnumerator use()
    {
        if (!slowingDown)
        {
            StartCoroutine(startTrying());
        }
        else if (currTime>cancelTime)
        {
            StartCoroutine(stopTrying());
        }
        yield return null;
    }

    IEnumerator startTrying()
    {
        //StartCoroutine(mainTracker.useStamina(10));
        controller.forwardSpeed *= JacketSlowDown;
        controller.backwardSpeed *= JacketSlowDown;
        controller.strafeSpeed *= JacketSlowDown;
        slowingDown = true;
        transform.position += Camera.transform.rotation * new Vector3(0, movement, 0);
        yield return null;
    }

    IEnumerator stopTrying()
    {
        currTime = 0;
        controller.forwardSpeed /= JacketSlowDown;
        controller.backwardSpeed /= JacketSlowDown;
        controller.strafeSpeed /= JacketSlowDown;
        slowingDown = false;
        transform.position += Camera.transform.rotation * new Vector3(0, -movement, 0);

        if (nextToPlayer == 1)
            StartCoroutine(aT.stopRightHand());
        else
            StartCoroutine(aT.stopLeftHand());

        yield return null;
    }

    IEnumerator destroyMe()
    {
        Destroy(gameObject);
        yield return null;
    }
}
