using UnityEngine;
using System.Collections;

public class FireAx : ItemPickup {
    GameObject player;
    Detection Det;

    private float SWING_SPEED = 1.5f;
    private string ACTION = "Swinging Fireaxe";

    private float currTime = 0f;
    private bool swinging = false;

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

    public override void Update()
    {
        base.Update();
        if (swinging)
        {
            currTime += Time.deltaTime;

            if (nextToPlayer == 0)
            {
                StartCoroutine(stopTrying());
            }
            else if (nextToPlayer == 1)
            {
                StartCoroutine(aT.rightHandAction(ACTION, SWING_SPEED, currTime));
            }
            else
            {
                StartCoroutine(aT.leftHandAction(ACTION, SWING_SPEED, currTime));
            }
            
            if (currTime > SWING_SPEED)
            {
                Debug.Log(Det.hitMe.collider.tag);
                if (Det.hitMe.collider.tag == tagFurn)
                {
                    GameObject furn = Det.hitMe.transform.gameObject;

                    Destroy(furn);
                }
                StartCoroutine(stopTrying());
            }
        }
    }

    public IEnumerator stopTrying()
    {
        swinging = false;
        currTime = 0f;
        if (nextToPlayer == 1)
            StartCoroutine(aT.stopRightHand());
        else
            StartCoroutine(aT.stopLeftHand());

        yield return null;
    }

    public override IEnumerator use()
    {
        swinging = true;
        yield return null;
    }
}
