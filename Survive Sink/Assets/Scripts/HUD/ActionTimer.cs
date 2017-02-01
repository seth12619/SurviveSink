using UnityEngine;
using System.Collections;

public class ActionTimer : MonoBehaviour {
    int actionBoxWidth = 200;
    int actionBoxHeight = 25;

    int bigTimerBoxWidth = 700;
    int bigTimerBoxHeight = 25;

    int smallTimerBoxWidth = 690;
    int smallTimerBoxHeight = 21;

    int aBox1X;
    int aBox1Y;
    int bTBox1X;
    int bTBox1Y;
    int sTBox1X;
    int sTBox1Y;
    string aName1 = "";
    float max1 = 0;
    float currTime1 = 0;

    int aBox2X;
    int aBox2Y;
    int bTBox2X;
    int bTBox2Y;
    int sTBox2X;
    int sTBox2Y;

    string aBox1Name;
    float aBox1Max;
    float aBox1CurrTime;
    string aBox2Name;
    float aBox2Max;
    float aBox2CurrTime;

    bool drawRight = false;
    bool drawLeft = false;

    float temp = 0;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        aBox1X = Screen.width / 2 - actionBoxWidth / 2;
        aBox1Y = Screen.height * 3 / 4;
        bTBox1X = Screen.width / 2 - bigTimerBoxWidth / 2;
        bTBox1Y = aBox1Y + actionBoxHeight;
        sTBox1X = Screen.width / 2 - smallTimerBoxWidth / 2;
        sTBox1Y = bTBox1Y + 2;

        aBox2X = Screen.width / 2 - actionBoxWidth / 2;
        aBox2Y = bTBox1Y + bigTimerBoxHeight;
        bTBox2X = Screen.width / 2 - bigTimerBoxWidth / 2;
        bTBox2Y = aBox2Y + actionBoxHeight;
        sTBox2X = Screen.width / 2 - smallTimerBoxWidth / 2;
        sTBox2Y = bTBox2Y + 2;
    }

    public IEnumerator rightHandAction(string name, float max, float currTime)
    {
        drawRight = true;
        aBox1Name = name;
        aBox1Max = max;
        aBox1CurrTime = currTime;
        yield return null;
    }

    public IEnumerator stopRightHand()
    {
        drawRight = false;
        yield return null;
    }

    public IEnumerator leftHandAction(string name, float max, float currTime)
    {
        drawLeft = true;
        aBox2Name = name;
        aBox2Max = max;
        aBox2CurrTime = currTime;
        yield return null;
    }

    public IEnumerator stopLeftHand()
    {
        drawLeft = false;
        yield return null;
    }

    void OnGUI()
    {
        if (drawRight)
        {
            float remTime = (aBox1Max - aBox1CurrTime);
            if (remTime > 0)
            {
                GUI.Box(new Rect(aBox1X, aBox1Y, actionBoxWidth, actionBoxHeight), aBox1Name + " " + remTime.ToString("#.00"));
                GUI.Box(new Rect(bTBox1X, bTBox1Y, bigTimerBoxWidth, bigTimerBoxHeight), "");
                GUI.Box(new Rect(sTBox1X, sTBox1Y, smallTimerBoxWidth * remTime / aBox1Max, smallTimerBoxHeight), "");
            }
        }
        if (drawLeft)
        {
            float remTime = (aBox2Max - aBox2CurrTime);
            if (remTime > 0)
            {
                GUI.Box(new Rect(aBox2X, aBox2Y, actionBoxWidth, actionBoxHeight), aBox2Name + " " + remTime.ToString("#.00"));
                GUI.Box(new Rect(bTBox2X, bTBox2Y, bigTimerBoxWidth, bigTimerBoxHeight), "");
                GUI.Box(new Rect(sTBox2X, sTBox2Y, smallTimerBoxWidth * remTime / aBox2Max, smallTimerBoxHeight), "");
            }
        }
    }
}
