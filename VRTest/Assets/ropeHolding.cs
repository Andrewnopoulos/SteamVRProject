using UnityEngine;
using System.Collections;

public class ropeHolding : MonoBehaviour {

    Transform anchorTransform;

	// Use this for initialization
	void Start () {
        
	}

    void Awake()
    {
        anchorTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = anchorTransform.position;
        transform.rotation = anchorTransform.rotation;
	}
}
