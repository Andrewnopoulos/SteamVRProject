using UnityEngine;
using System.Collections;

public class BoidScript : MonoBehaviour {

    
    SteamVR_Controller.Device rightController;

    Rigidbody body;

    public float forceMagnitude;

    public float lifetime = 4.0f;

    float aliveTime;

    bool ableToGravitate;

    public float explosionForce;

	// Use this for initialization
	void Start () {
        rightController = new SteamVR_Controller.Device(4);

        body = GetComponent<Rigidbody>();

        aliveTime = 0.0f;

        ableToGravitate = true;
	}
	
	// Update is called once per frame
	void Update () {

        aliveTime += Time.deltaTime;

        if (aliveTime > lifetime)
        {
            Destroy(this.gameObject);
        }

        if (SteamVR_Controller.Input(4).GetHairTrigger() && ableToGravitate)
        {
            Vector3 gravityForce = rightController.transform.pos - transform.position;
            if (gravityForce.magnitude != 0)
            {
                gravityForce /= gravityForce.magnitude;
                body.AddForce(gravityForce * forceMagnitude);
            }
            body.useGravity = false;

            if (SteamVR_Controller.Input(4).GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                ableToGravitate = false;
                body.AddExplosionForce(explosionForce, rightController.transform.pos, 1.0f);
            }
        }
        else if (SteamVR_Controller.Input(4).GetHairTriggerUp())
        {
            body.useGravity = true;
            ableToGravitate = false;
        }

        
        
        Vector3.RotateTowards(transform.forward, body.velocity, 0.5f, 0.8f);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<Enemy>().SendMessage("TakeHit", SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
