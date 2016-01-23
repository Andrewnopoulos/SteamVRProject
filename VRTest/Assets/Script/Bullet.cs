using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject m_bulletHolePrefab;
    public float m_lifetime = 1.0f;

    void Update()
    {
        m_lifetime -= Time.deltaTime;

        if(m_lifetime < 0)
        {
            BulletDestroy(false);
        }
    }
    
	void OnCollisionEnter(Collision other)
    {
        GameObject bulletHole = Instantiate<GameObject>(m_bulletHolePrefab);
        bulletHole.transform.forward = -other.contacts[0].normal;
        bulletHole.transform.position = other.contacts[0].point + other.contacts[0].normal * 0.001f;

        BulletDestroy(true);
    }

    public void BulletDestroy(bool _particleEffects)
    {
        if(_particleEffects)
        {
            //Spawn particles! :3

        }

        Destroy(this.gameObject);
    }
}
