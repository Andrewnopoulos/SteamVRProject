using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Animator animator;
    NavMeshAgent agent;

    public int m_health = 4;

    private bool dying = false;

    public float timeDead = 10;

    private bool inactive = false;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(m_health <= 0 && !dying)
        {
            animator.SetTrigger("dead");
            dying = true;
            animator.SetBool("playingDeathAnim", true);
            agent.SetDestination(transform.position);
            agent = null;
        }
        
        if (m_health >= 0 && !dying)
        {
            agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        }

        if (dying && !animator.GetBool("playingDeathAnim"))
        {
            animator.Stop();
            inactive = true;
        }

        if (inactive)
        {
            timeDead -= Time.deltaTime;
            if (timeDead < 0)
            {
                Destroy(this.gameObject);
            }
        }
	}

    public void TakeHit()
    {
        m_health--;
        animator.SetTrigger("hit");
    }
}