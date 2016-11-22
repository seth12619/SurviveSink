using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{

    [Header("Pickup Settings")]
    [Tooltip("Scale of object when picked up. (Doesn't Work)")]
    protected float pickUpScale = 0.25f;

    [Header("Tilt Settings")]
    [Tooltip("Tilt of object in the X. (Degrees)")]
    protected float X_DEG_Shift = 126;
    [Tooltip("Tilt of object in the Y. (Degrees)")]
    protected float Y_DEG_Shift = 190;
    [Tooltip("Tilt of object in the Z. (Degrees)")]
    protected float Z_DEG_Shift = -111;

    [Header("Offset Settings")]
    [Tooltip("Offset of object in the X when Picked up. (Degrees)")]
    protected float XShift = 0.3f;
    [Tooltip("Offset of object in the Y when Picked up. (Degrees)")]
    protected float YShift = -0.1f;
    [Tooltip("Offset of object in the Z when Picked up. (Degrees)")]
    protected float ZShift = 0.2f;

    private int pickupRectWidth = 250;
    private int rectXMargin = 20;
    private int rectYMargin = 20;

    new private Rigidbody rigidbody;
    private MeshRenderer meshRend;
    private float rigidbodyMass;
    protected GameObject Camera;

    // 0 means player isn't holding item. -1 means left hand and 1 means right hand.
    protected int nextToPlayer = 0;

    // Use this for initialization
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRend = GetComponent<MeshRenderer>();
        rigidbodyMass = rigidbody.mass;
        Camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (nextToPlayer != 0)
        {
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

    public virtual IEnumerator use()
    {
        yield return null;
    }

    void attachToPlayer()
    {
        meshRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        transform.localScale *= pickUpScale;

        transform.rotation = Quaternion.Euler(X_DEG_Shift, Y_DEG_Shift * nextToPlayer, Z_DEG_Shift * nextToPlayer);
        transform.rotation = Camera.transform.rotation * transform.rotation;
        rigidbody.isKinematic = true;
        rigidbody.detectCollisions = false;
        transform.position = Camera.transform.position + Camera.transform.rotation * new Vector3(XShift * nextToPlayer * pickUpScale, YShift * pickUpScale, ZShift * pickUpScale);
        transform.parent = Camera.transform;
    }

    public IEnumerator detachFromPlayer()
    {
        meshRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        rigidbody.isKinematic = false;
        rigidbody.detectCollisions = true;
        transform.parent = null;
        transform.localScale /= pickUpScale;
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
            GUI.Box(new Rect(rectXMargin, rectYMargin, pickupRectWidth, 25), "Press 'Q' or 'L1' to pick up in your left hand");
            GUI.Box(new Rect(Screen.width - rectXMargin - pickupRectWidth, rectYMargin, pickupRectWidth, 25), "Press 'R' or 'R1' to pick up in your right hand");
        }
    }
}
