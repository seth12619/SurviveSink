using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{

    [Header("Pickup Settings")]
    [Tooltip("Scale of object when picked up. (Doesn't Work)")]
    public float pickUpScale = 0.25f;

    [Header("Tilt Settings")]
    [Tooltip("Tilt of object in the X. (Degrees)")]
    public float X_DEG_Shift = 126;
    [Tooltip("Tilt of object in the Y. (Degrees)")]
    public float Y_DEG_Shift = 190;
    [Tooltip("Tilt of object in the Z. (Degrees)")]
    public float Z_DEG_Shift = -111;

    [Header("Offset Settings")]
    [Tooltip("Offset of object in the X when Picked up. (Degrees)")]
    private float XShift = 0.3f;
    [Tooltip("Offset of object in the Y when Picked up. (Degrees)")]
    private float YShift = -0.1f;
    [Tooltip("Offset of object in the Z when Picked up. (Degrees)")]
    private float ZShift = 0.2f;

    private int pickupRectWidth = 250;
    private int rectXMargin = 20;
    private int rectYMargin = 20;

    private Rigidbody rigidbody;
    private float rigidbodyMass;

    // 0 means player isn't holding item. -1 means left hand and 1 means right hand.
    private int nextToPlayer = 0;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbodyMass = rigidbody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextToPlayer != 0)
        {
            GameObject Camera = GameObject.Find("Camera");

            transform.rotation = Quaternion.Euler(X_DEG_Shift, Y_DEG_Shift * nextToPlayer, Z_DEG_Shift * nextToPlayer);
            transform.position = Camera.transform.position + Camera.transform.rotation*new Vector3(XShift * nextToPlayer * pickUpScale, YShift * pickUpScale, ZShift * pickUpScale);

            transform.rotation = Camera.transform.rotation * transform.rotation;
        }
        else
        {
            if (rigidbody.IsSleeping())
            {
                rigidbody.WakeUp();
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
        rigidbody.constraints = RigidbodyConstraints.None;
        transform.localScale *= pickUpScale;
    }

    public IEnumerator detachFromPlayer()
    {
        //GameObject Camera = GameObject.Find("Camera");
        //transform.position = Camera.transform.position + Quaternion.Euler(Camera.transform.rotation.x, 0, Camera.transform.rotation.z) 
        //* new Vector3(XShift * nextToPlayer, 0, ZShift);
        transform.localScale /= pickUpScale;
        //transform.position = Camera.transform.position + Camera.transform.rotation.x * new Vector3(XShift * nextToPlayer, 0, ZShift);
        //transform.position = Camera.transform.position + Camera.transform.rotation * new Vector3(0,0,ZShift);
        nextToPlayer = 0;
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
