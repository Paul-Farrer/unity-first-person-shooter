using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float chaseRadius = 10f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private AudioClip moaning;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity; // set variable to the biggest number possible
    private bool isProvoked = false;
    private bool isDead = true;
    private Transform target;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); // distance to target

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRadius)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(moaning);
            }
            isProvoked = true;
            // navMeshAgent.SetDestination(target.position);
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        // if (distanceToTarget <= chaseRadius || isProvoked)
        // {
        //     isProvoked = false;
        // chase target if not close enough
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        // if enemy is close enough to target attack
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        //}
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Attack");
    }

    public void Dead()
    {
        if (isDead)
        {
            GetComponent<NavMeshAgent>().speed = 0;
            GetComponent<Animator>().SetTrigger("Dead");
            isDead = false;
        }

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; // returns vector with a magnitude of 1
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); // slerp = spherical interpolation, allows to rotate smoothly between 2 vectors 
    }

    // draws a sphere around the enemies viewing distance when selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
