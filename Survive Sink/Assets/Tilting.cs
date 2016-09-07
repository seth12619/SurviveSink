using UnityEngine;
using System.Collections;


public class Tilting : MonoBehaviour {
    private float currXDeg;
    private float currZDeg;
    private float targetXDeg;
    private float targetZDeg;
    private int turningRight;
    private int currIncrements;

    private static double PERCENTAGE_TURN = 0.85;
    private static int INCREMENT_RANGE = 1000;
    private static int INCREMENT_START = 600;
    private static float Z_DEG_RANGE = 10;
    private static float X_DEG_RANGE = 25;
    private static int INCREMENT_MIN = 0;

	// Use this for initialization
	void Start () {
        currXDeg = 0;
        currZDeg = 0;
        currIncrements = INCREMENT_MIN;
        turningRight = -1;
        targetXDeg = 0;
        targetZDeg = 0;
	}
	
	// Update is called once per frame
	void Update () {
        decideAction();
	}

    void decideAction() {
        if (currIncrements == INCREMENT_MIN)
        {
            currIncrements = (int)(Random.Range(0.0f, 1.0f) * INCREMENT_RANGE) + INCREMENT_START;
            bool turn = Random.Range(0.0f, 1.0f) > PERCENTAGE_TURN;
            if (turn) {
                turningRight *= -1;
            }
            targetXDeg = Random.Range(0.0f, X_DEG_RANGE)*turningRight;
            targetZDeg = Random.Range(-Z_DEG_RANGE, Z_DEG_RANGE);
        }
        moveToAngle(targetXDeg, targetZDeg, currIncrements);
    }

    bool moveToAngle (float xDeg, float zDeg, int increments) {
        float tempX = xDeg - currXDeg;
        tempX = tempX / increments;

        float tempZ = zDeg - currZDeg;
        tempZ = tempZ / increments;

        transform.Rotate(-currXDeg, 0, 0);
        transform.Rotate(0, 0, -currZDeg);

        currXDeg += tempX;
        currZDeg += tempZ;
        currIncrements = increments - 1;
        Debug.Log(currIncrements);
        Debug.Log("XDeg: " + currXDeg + ", ZDeg: " + currZDeg);
        Debug.Log("XDeg: " + xDeg + ", ZDeg: " + zDeg);
        Debug.Log(Time.deltaTime);

        transform.Rotate(0, 0, currZDeg);
        transform.Rotate(currXDeg, 0, 0);
        
        if(currIncrements==0)
            return true;
        return false;
    }
}
