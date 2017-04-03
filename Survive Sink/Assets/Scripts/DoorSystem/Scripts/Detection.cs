using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Detection : MonoBehaviour
{
    public RaycastHit hitMe;

	// INSPECTOR SETTINGS
	[Header("Detection Settings")]
	[Tooltip("Within this radius the player is able to open/close the door")]
	public float Reach = 4F;
	[Tooltip("The tag that triggers the object to be openable")]
	public string TriggerTag = "Door";

	// PRIVATE SETTINGS
	[HideInInspector] public bool InReach;

	//DEBUGGING (DEBUG PANEL)
	[Header("Debug Settings")]
	public Color DebugRayColor = Color.green;
	public bool InGameDebugger = false;

	string CategoryDetection = "Detection";
	string TitleReach = "Reach";
	string TitleInReach = "InReach";

	string CategoryDoor = "Door";
	string TitleHitTag = "HitTag";
	string TitleHingeSide = "HingeSide";
	string TitleCurrentAngle = "CurrentAngle";
	string TitleSpeed = "Speed";
	string TitleTimesMoveable = "TimesMoveable";
	string TitleRunning = "Running";

    MeshRenderer[] oldMeshRenderers;
    Shader[] oldShaders;

    bool oldInReach = false;
    RaycastHit oldHit;

    public Shader itemHighlightShader;

    PlayerGrit grit;


	//START FUNCTION
	void Start()
	{

	}

	//AWAKE
	void Awake()
	{
		grit = GetComponent<PlayerGrit>();
	}

	//UPDATE FUNCTION
	public void Update()
	{
		// Set origin of ray to 'center of screen' and direction of ray to 'cameraview'.
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0F));

		RaycastHit hit; // Variable reading information about the collider hit.

		// Cast a ray from the center of screen towards where the player is looking.
		if (Physics.Raycast (ray, out hit, Reach))
		{
            //DEBUGGING (DEBUG PANEL)
            //DebugPanel.Log(TitleHitTag, CategoryDoor, hit.collider.tag);
            hitMe = hit;

			if (hit.collider.tag == TriggerTag || hit.collider.tag == "EndingTrigger" || hit.collider.tag == "Stuck Debris") {
				InReach = true;

				doAction (hit);
			} 
				

			else InReach = false;

		}

		else
		{
			InReach = false;
		}

        highlight();
    }

    private void highlight()
    {
        if (!oldInReach && InReach)
        {
            changeShaders();
        }
        else if (oldInReach)
        {
            if (oldHit.transform.gameObject != hitMe.transform.gameObject)
            {
                changeBackShaders();
                if (hitMe.collider.tag == TriggerTag)
                    changeShaders();
            }
            else if (!InReach)
            {
                changeBackShaders();
            }
        }
        oldInReach = InReach;
    }

    public virtual void doAction(RaycastHit hit)
    {
        if (Input.GetButtonDown("Use"))
        {
			if (hit.collider.tag == "EndingTrigger") {
				Debug.Log ("Quit!");
                //Application.Quit ();
                StartCoroutine(GameObject.Find("Tracker").GetComponent<MainTracker>().endDay());
				SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
				Time.timeScale = 0; 
			} else if (hit.collider.tag == "Stuck Debris") {
				Destroy (hit.transform.gameObject);
				grit.takeDamage (20);
			} else {
				// Give the object that was hit the name 'Door'.
				GameObject Door = hit.transform.gameObject;

				// Get access to the 'DoorOpening' script attached to the door that was hit.
				Door dooropening = Door.GetComponent<Door> ();

				// Check whether the door is opening/closing or not.
				if (dooropening.Running == false) {
					// Open/close the door by running the 'Open' function in the 'DoorOpening' script.
					StartCoroutine (hit.collider.GetComponent<Door> ().Open ());
				}
			}
        }

    }

    private void changeShaders()
    {
        oldHit = hitMe;
        oldMeshRenderers = oldHit.transform.gameObject.GetComponentsInChildren<MeshRenderer>();
        oldShaders = new Shader[oldMeshRenderers.Length];
        for (int i = 0; i != oldMeshRenderers.Length; i++)
        {
            oldShaders[i] = oldMeshRenderers[i].material.shader;
            oldMeshRenderers[i].material.shader = itemHighlightShader;
        }
    }

    private void changeBackShaders()
    {
        for (int i = 0; i != oldMeshRenderers.Length; i++)
        {
            oldMeshRenderers[i].material.shader = oldShaders[i];
        }
    }
}
