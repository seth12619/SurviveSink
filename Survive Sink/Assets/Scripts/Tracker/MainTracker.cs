using UnityEngine;
using System.Collections;

public class MainTracker : MonoBehaviour {
    private int lifeJacketTracker;

	// Use this for initialization
	void Start () {
        lifeJacketTracker = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator addLifeJacket()
    {
        lifeJacketTracker++;
        yield return null;
    }
}
