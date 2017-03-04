using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    [Header("Shatters into...")]
    [Tooltip("Attach the GameObject it shatter to here...")]
    public GameObject debris;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator destroyMe()
    {
        if(debris != null)
            Instantiate(debris, transform.position, transform.rotation);
        Destroy(gameObject);
        yield return null;
    }
}
