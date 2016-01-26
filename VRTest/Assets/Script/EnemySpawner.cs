using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject m_enemyPrefab;

    public float m_spawnDelay = 5;
    float m_spawnTimer;

	// Use this for initialization
	void Start ()
    {
        float initialspawnOffset = Random.RandomRange(0, m_spawnDelay);
        m_spawnTimer = initialspawnOffset;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_spawnTimer -= Time.deltaTime;

        if(m_spawnTimer < 0)
        {
            m_spawnTimer = m_spawnDelay;
            GameObject enemy = Instantiate<GameObject>(m_enemyPrefab);
            enemy.transform.position = transform.position;
        }
	}
}
