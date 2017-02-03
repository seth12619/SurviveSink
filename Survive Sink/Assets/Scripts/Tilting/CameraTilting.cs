using UnityEngine;
using System.Collections;

public class CameraTilting : WaitTilting {
    float currYDeg = 0;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        currYDeg = player.transform.rotation.y;
    }

    /*public override Vector3 getXDegVector(float xDeg, bool reverse)
    {
        temp = base.getXDegVector(xDeg, reverse);
    }

    public override Vector3 getZDegVector(float zDeg, bool reverse)
    {
        temp = base.getXDegVector(xDeg, reverse);
    }*/
}
