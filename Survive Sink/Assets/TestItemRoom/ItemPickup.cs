using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{

    [Header("Pickup Settings")]
    [Tooltip("Scale of object when picked up. (Doesn't Work)")]
    public float pickUpScale = 1;
    [Tooltip("Tilt of object in the X. (Degrees)")]
    public float X_DEG_Shift = 126;
    [Tooltip("Tilt of object in the Y. (Degrees)")]
    public float Y_DEG_Shift = 190;
    [Tooltip("Tilt of object in the Z. (Degrees)")]
    public float Z_DEG_Shift = -111;

    private int pickupRectWidth = 250;
    private int rectXMargin = 20;
    private int rectYMargin = 20;

    private float ZShift = 0.4f;
    private float XShift = 0.3f;
    private float YShift = 0.033f;

    private Rigidbody rigidbody;

    // 0 means player isn't holding item. -1 means left hand and 1 means right hand.
    private int nextToPlayer = 0;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextToPlayer != 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                StartCoroutine(detachFromPlayer());
            }
            else
            {
                GameObject Player = GameObject.Find("Player");
                GameObject Camera = GameObject.Find("Camera");

                transform.rotation = Quaternion.Euler(X_DEG_Shift, Y_DEG_Shift * nextToPlayer, Z_DEG_Shift * nextToPlayer);
                transform.position = Player.transform.position + Camera.transform.rotation*new Vector3(XShift * nextToPlayer, YShift, ZShift);
                Debug.Log(transform.position);

                transform.rotation = Camera.transform.rotation * transform.rotation;
            }
        }
    }

    public IEnumerator attachToPlayerRight()
    {
        nextToPlayer = 1;
        attachToPlayer();
        yield return null;
    }

    public IEnumerator attachToPlayerLeft()
    {
        nextToPlayer = -1;
        attachToPlayer();
        yield return null;
    }

    void attachToPlayer()
    {
        //transform.localScale *= pickUpScale;
        rigidbody.isKinematic = true;
        
    }

    public IEnumerator detachFromPlayer()
    {
        //transform.localScale /= pickUpScale;
        nextToPlayer = 0;
        rigidbody.isKinematic = false;
        yield return null;
    }

    void OnGUI()
    {
        // Access InReach variable from raycasting script.
        GameObject Player = GameObject.Find("Player");
        Detection detection = Player.GetComponent<ItemDetection>();

        if (detection.InReach == true)
        {
            GUI.color = Color.white;
            GUI.Box(new Rect(rectXMargin, rectYMargin, pickupRectWidth, 25), "Press 'Q' to pick up in your left hand");
            GUI.Box(new Rect(Screen.width - rectXMargin - pickupRectWidth, rectYMargin, pickupRectWidth, 25), "Press 'R' to pick up in your right hand");
        }
    }
}
