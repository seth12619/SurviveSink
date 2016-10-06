using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public bool start;
	public bool quit;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseUp() {
		if (start) {
			SceneManager.LoadScene("Main", LoadSceneMode.Single);
			GetComponent<Renderer>().material.color=Color.cyan;
		}
		if (quit) {
			Application.Quit();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
