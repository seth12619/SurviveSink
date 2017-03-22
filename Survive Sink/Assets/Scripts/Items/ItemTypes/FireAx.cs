using UnityEngine;
using System.Collections;

public class FireAx : ItemPickup {
    GameObject player;
    Detection Det;

    private static float ORIG_X_DEG_Shift = -10;
    private static float ORIG_Y_DEG_Shift = -100;
    private static float ORIG_Z_DEG_Shift = -30;
    private static float SWING_X_DEG_SHIFT = 90;

    private float SWING_SPEED = 0.75f;
    private string ACTION = "Swinging Fireaxe";

    private float currTime = 0f;
    private bool swinging = false;

    private string tagFurn = "Furniture";
	private string tagDebris = "Debris";

    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        Det = player.GetComponent<ItemDetection>();

        pickUpScale = 0.05f;
        X_DEG_Shift = ORIG_X_DEG_Shift;
        Y_DEG_Shift = ORIG_Y_DEG_Shift;
        Z_DEG_Shift = ORIG_Z_DEG_Shift;
        XShift = 0.1f;
        YShift = -0.4f;
        ZShift = 0.2f;
    }

    public override void Update()
    {
        base.Update();
        X_DEG_Shift = ORIG_X_DEG_Shift + currTime / SWING_SPEED * SWING_X_DEG_SHIFT;
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
                if ((Det.hitMe.collider.tag == tagFurn)|| (Det.hitMe.collider.tag==tagDebris))
                {
                    GameObject furn = Det.hitMe.transform.gameObject;
                    Destructible destruct = furn.GetComponent<Destructible>();

                    if (destruct != null){
                        StartCoroutine(destruct.destroyMe());
                    }
                    else {
                        Destroy(furn);
                    }
                }
                StartCoroutine(stopTrying());
            }
        }
    }

    public IEnumerator stopTrying() {
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
        StartCoroutine(mainTracker.useStamina(80));
        swinging = true;
        yield return null;
    }
}
