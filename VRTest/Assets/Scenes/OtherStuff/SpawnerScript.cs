using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
    
    SteamVR_Controller.Device leftController;

    public GameObject boid;

    public float expulsionForce = 5;

    public float spawnDelay = 0.01f;

    float spawnTimer = 0.0f;

	// Use this for initialization
	void Start () {
        
	}

    void Awake()
    {
        leftController = new SteamVR_Controller.Device(3);
        Debug.Log(leftController.index);
    }
	
	// Update is called once per frame
	void Update () {

        spawnTimer += Time.deltaTime;

        if (SteamVR_Controller.Input(3).GetHairTrigger() && spawnTimer > spawnDelay)
        {
            GameObject newboid = Instantiate<GameObject>(boid);
            newboid.transform.position = transform.position;
            newboid.GetComponent<Rigidbody>().AddForce(transform.forward * expulsionForce);
            newboid.GetComponent<Rigidbody>().AddForce(SteamVR_Controller.Input(3).velocity * 100);
            spawnTimer = 0.0f;
        }
	}
}