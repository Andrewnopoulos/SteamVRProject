using UnityEngine;
using System.Collections;

public class BulletHoleScript : MonoBehaviour {

    public float lifeTime = 5.0f;
    private float currentLifetime;

    Material mat;

	// Use this for initialization
	void Start () {
        currentLifetime = lifeTime;

        mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        currentLifetime -= Time.deltaTime;

        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, currentLifetime / lifeTime);

        if (currentLifetime < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
