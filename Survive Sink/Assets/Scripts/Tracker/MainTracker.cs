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

    public IEnumerator addLifeJacket()
    {
        lifeJacketTracker++;
        Debug.Log(lifeJacketTracker);
        yield return null;
    }
}
