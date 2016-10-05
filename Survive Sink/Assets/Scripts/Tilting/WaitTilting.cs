using UnityEngine;
using System.Collections;

public class WaitTilting : Tilting {
    [Header("Wait Settings")]
    [Tooltip("Modifier for wait time.")]
    public double MODIFIER = 0.8;

    private int WAIT_TIME_RANGE = (int) (2000);
    private int WAIT_TIME_FLOOR = (int) (1000);
    private int WAIT_TIME_BUFFER = (int) (1000);

    private int waitTime = 0;
    private int currentMaxWaitTime = 0;

    public override void decideAction()
    {
        if (waitTime > 0)
        {
            waitTime--;
            base.moveToAngle(0,0,getWAIT_TIME_RANGE() + getWAIT_TIME_FLOOR() + getWAIT_TIME_BUFFER() - currentMaxWaitTime + waitTime);
        }
        else
        {
            int temp = base.randomMovement();
            if (temp == 0)
            {
                setRandomWaitTime();
            };
        }
    }

    int getWAIT_TIME_RANGE()
    {
        return (int) (WAIT_TIME_RANGE / MODIFIER);
    }

    int getWAIT_TIME_FLOOR()
    {
        return (int)(WAIT_TIME_FLOOR / MODIFIER);
    }

    int getWAIT_TIME_BUFFER()
    {
        return (int)(WAIT_TIME_BUFFER / MODIFIER);
    }

    void setWaitTime(int x)
    {
        waitTime = x;
        currentMaxWaitTime = x;
    }

    void setRandomWaitTime()
    {
        setWaitTime((int)Random.Range(0.0f, 1.0f) * WAIT_TIME_RANGE + WAIT_TIME_FLOOR);
    }
}
