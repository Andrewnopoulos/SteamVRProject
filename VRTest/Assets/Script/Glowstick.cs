using UnityEngine;
using System.Collections;

public class Glowstick : MonoBehaviour {

    public float m_minimumVelocity;
    public float m_minimumIntensity;
    public float m_maximumIntensity;
    public float m_intensityIncrease;
    public float m_intensityDecrease;

    SteamVR_Controller.Device controller = new SteamVR_Controller.Device(1);// = new SteamVR_Controller.Device(3);

	// Use this for initialization
	void Start ()
    {
        //SteamVR_TrackedObject.EIndex index = GetComponentInParent<SteamVR_TrackedObject>().index;
        //controller = new SteamVR_Controller.Device((uint)index);
        //print("SPare line so we can debug");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Light light = GetComponent<Light>();

	    if(controller.velocity.magnitude > m_minimumVelocity && light.intensity < m_maximumIntensity)
        {
           
            light.intensity += m_intensityIncrease * Time.deltaTime;
        }

        if(light.intensity > m_minimumIntensity)
            light.intensity += m_intensityDecrease * Time.deltaTime;
	}
}
