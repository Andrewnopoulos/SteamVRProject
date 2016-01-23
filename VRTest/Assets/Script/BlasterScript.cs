using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {

    SteamVR_Controller.Device controller;

    public GameObject bulletPrefab;

    public float bulletVelocity;

	// Use this for initialization
	void Start () {
        SteamVR_TrackedObject.EIndex index = GetComponentInParent<SteamVR_TrackedObject>().index;
        controller = new SteamVR_Controller.Device((uint)index);
	}
	
	// Update is called once per frame
	void Update () {
	    if (controller.GetHairTriggerDown())
        {
            GameObject clone = (GameObject)Instantiate(bulletPrefab, transform.position + -transform.right * 0.27f + transform.up * 0.03f, transform.rotation);
            clone.transform.Rotate(new Vector3(0, 0, 1), 90);
            clone.GetComponent<Rigidbody>().AddForce(-transform.right * bulletVelocity);
        }
	}
}
