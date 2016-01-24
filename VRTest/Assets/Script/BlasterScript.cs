using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {

    public GameObject bulletPrefab;
    public float bulletVelocity;
    public float m_battery = 5;
    public float m_batterySize = 10;
    public float m_fireCost = 2;
    public float m_chargeAmount = 1;

    float chargeOriginScale;

    GameObject charge;
    SteamVR_Controller.Device controller;
    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        SteamVR_TrackedObject.EIndex index = GetComponentInParent<SteamVR_TrackedObject>().index;
        controller = new SteamVR_Controller.Device((uint)index);

        lineRenderer = GetComponent<LineRenderer>();
        charge = transform.FindChild("Charge").gameObject;

        chargeOriginScale = charge.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lineRenderer.SetPosition(0, transform.position + -transform.right * 0.02f + transform.up * 0.03f);
        lineRenderer.SetPosition(1, transform.position + -transform.right * 5 + transform.up * 0.03f);

        charge.transform.localScale = new Vector3(charge.transform.localScale.x, chargeOriginScale * m_battery, 1.0f);

	    if (controller.GetHairTriggerDown() && m_battery - m_fireCost > 0)
        {
            m_battery -= m_fireCost;

            GameObject clone = (GameObject)Instantiate(bulletPrefab, transform.position + -transform.right * 0.27f + transform.up * 0.03f, transform.rotation);
            clone.transform.Rotate(new Vector3(0, 0, 1), 90);
            clone.GetComponent<Rigidbody>().AddForce(-transform.right * bulletVelocity);
        }

        if (m_battery <= m_batterySize)
            m_battery += m_chargeAmount * Time.deltaTime;
	}
}
