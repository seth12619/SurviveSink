using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float TimeInterval = 0.25f;
    float timePassed = 0f;
    float startedWithTime;
    public float expireTime = 180f;
    public GameObject fire;
    public GameObject realFire;
    public bool onFire = true;

    Flammable burn;

    // Use this for initialization
    void Start()
    {
        if (onFire)
        {
            StartCoroutine(startFire());
        }
        startedWithTime = expireTime;

        burn = transform.parent.gameObject.GetComponent<Flammable>();

        if (!onFire)
        {
            StartCoroutine(stopFire());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            expireTime -= Time.deltaTime;

            float absTimePassed = startedWithTime * 1.1f - expireTime;
            float modifier = absTimePassed * absTimePassed / startedWithTime / startedWithTime;

            timePassed += Time.deltaTime * modifier;
            if (timePassed > TimeInterval)
            {
                timePassed = 0;
                StartCoroutine(createFire());
            }

            if (expireTime < 0)
            {
                if (burn != null)
                    StartCoroutine(burn.burn());
                else
                    Destroy(transform.parent.gameObject);
            }
        }
    }

    IEnumerator createFire()
    {
        Instantiate(fire, transform.position, transform.rotation);
        yield return null;
    }

    public IEnumerator stopFire()
    {
        onFire = false;
        Destroy(transform.Find("RealFire(Clone)").gameObject);
        tag = "UnlitFire";
        yield return null;
    }

    public IEnumerator startFire()
    {
        onFire = true;
        GameObject temp = Instantiate(realFire, transform.position, transform.rotation);
        temp.transform.parent = transform;
        tag = "Fire";
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UnlitFire")
        {
            Fire x = other.gameObject.GetComponent<Fire>();
            StartCoroutine(x.startFire());
        }
    }
}

