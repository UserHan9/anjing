using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public Animator animator;
    public GameObject target;
    private NavMeshAgent navMeshAgent;
    public float speed = 5.0f;

    public float attackRange = 10.0f;  // Adjust this value as needed

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            Debug.Log(distanceToTarget);
            if (distanceToTarget <= attackRange)
            {
                Debug.Log("Within attack range");
                animator.SetBool("attack", true);
                animator.SetBool("run", false);
                navMeshAgent.isStopped = true;
                //speed *= 100.0f;// Stop the agent when attacking
            }
            else
            {
                Debug.Log("Outside attack range");
                animator.SetBool("attack", false);
                animator.SetBool("run", true);
                navMeshAgent.isStopped = false;  // Resume the agent movement
                navMeshAgent.SetDestination(target.transform.position);
            }
        }
        //Scare();
        //Debug.Log(speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Optional: Add any additional logic for when the player is first detected
            Debug.Log("Player detected");
        }
    }

    public void Scare()
    {

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarget <= attackRange)
        {
            speed *= 100.0f;
            
        }
    }
}
