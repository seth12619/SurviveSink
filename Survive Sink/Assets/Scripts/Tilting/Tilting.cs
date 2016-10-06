using UnityEngine;
using System.Collections;


public class Tilting : MonoBehaviour {
    private float currXDeg;
    private float currZDeg;
    private float targetXDeg;
    private float targetZDeg;
    private int turningRight;
    private int currIncrements;

    [Header("Tilt Settings")]
    [Tooltip("Percentage to tilt to the the other side.")]
    public double PERCENTAGE_TURN = 0.85;
    [Tooltip("Tilt range in the X coordinates. (Degrees)")]
    public float X_DEG_RANGE = 25;
    [Tooltip("Tilt range in the Z coordinates. (Degrees)")]
    public float Z_DEG_RANGE = 10;

    private static int INCREMENT_RANGE = 500;
    private static int INCREMENT_START = 250;
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

    /**
     *  Default DecideAction behavior for testing.
     */
    public virtual void decideAction() {
        randomMovement();
    }

    public int randomMovement()
    {
        if (currIncrements == getINCREMENT_MIN())
        {
            chooseRandTilt();
        }
        currIncrements = moveToAngle(targetXDeg, targetZDeg, currIncrements);

        return currIncrements;
    }

    /**
     *  Chooses the random tilt
     */
    public void chooseRandTilt()
    {
        int increments = (int)(Random.Range(0.0f, 1.0f) * getINCREMENT_RANGE()) + getINCREMENT_START();
        bool turn = Random.Range(0.0f, 1.0f) > getPERCENTAGE_TURN();
        if (turn)
        {
            turningRight *= -1;
        }
        float xDeg = Random.Range(0.0f, getX_DEG_RANGE()) * turningRight;
        float zDeg = Random.Range(-getZ_DEG_RANGE(), getZ_DEG_RANGE());
        refactorMovement(xDeg, zDeg, increments);
    }

    //Fundamental Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    /**
     *  Changes movement to move to new location with the given increments
     *
     *  @param tXDeg - float, XDeg to go to.
     *  @param tZDeg - float, ZDeg to go to.
     *  @param incStart - int, sets the increments + the mandatory minimum INCREMENT_START
     */
    public void refactorMovement(float tXDeg, float tZDeg, int incStart)
    {
        currIncrements = incStart + getINCREMENT_START();
        targetXDeg = tXDeg;
        targetZDeg = tZDeg;
    }

    /**
     *  Does one frame to move 1/increments to the angle given by xDeg, zDeg 
     *  
     *  @param xDeg - float
     *  @param zDeg - float
     *  @param increments - int
     *
     *  @return the increments after moving to the new angle.
     */
    public int moveToAngle (float xDeg, float zDeg, int increments) {
        float tempX = xDeg - currXDeg;
        tempX = tempX / increments;

        float tempZ = zDeg - currZDeg;
        tempZ = tempZ / increments;

        transform.Rotate(-currXDeg, 0, 0);
        transform.Rotate(0, 0, -currZDeg);

        currXDeg += tempX;
        currZDeg += tempZ;

        /*Debug.Log(currIncrements);
        Debug.Log("XDeg: " + currXDeg + ", ZDeg: " + currZDeg);
        Debug.Log("XDeg: " + xDeg + ", ZDeg: " + zDeg);
        Debug.Log(Time.deltaTime);*/

        transform.Rotate(0, 0, currZDeg);
        transform.Rotate(currXDeg, 0, 0);

        return increments - 1; 
    }

    /**
     *  Moves to angle given by the private stored values
     */
    public int autoMoveToAngle()
    {
        return moveToAngle(targetXDeg, targetZDeg, currIncrements);
    }

    //GETTER METHODS FOR CONSTANTS ----------------------------------------------------------------------

    double getPERCENTAGE_TURN()
    {
        return PERCENTAGE_TURN;
    }

    int getINCREMENT_RANGE()
    {
        return INCREMENT_RANGE;
    }

    int getINCREMENT_START()
    {
        return INCREMENT_START;
    }

    float getZ_DEG_RANGE()
    {
        return Z_DEG_RANGE;
    }

    float getX_DEG_RANGE()
    {
        return X_DEG_RANGE;
    }

    int getINCREMENT_MIN()
    {
        return INCREMENT_MIN;
    }
}
