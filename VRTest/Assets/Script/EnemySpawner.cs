using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject m_enemyPrefab;

    public float m_spawnDelay = 5;
    float m_spawnDelayOrigin;

	// Use this for initialization
	void Start ()
    {
        m_spawnDelayOrigin = m_spawnDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_spawnDelay -= Time.deltaTime;

        if(m_spawnDelay < 0)
        {
            m_spawnDelay = m_spawnDelayOrigin;
            GameObject enemy = Instantiate<GameObject>(m_enemyPrefab);
        }
	}
}
