using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //patroli
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //serang
    public float timeBetweenAttack;
    public bool alreadyAttack;

    //States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerAttackRange;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInsightRange && !playerAttackRange)
        {
            patroli();
            //SoundManager.PlaySound("mati");
        }
        if (playerInsightRange && !playerAttackRange)
        {
            kejar();
            //SoundManager.PlaySound("dikejar");
        }
        if (playerInsightRange && playerAttackRange)
        {
            serang();
        }
    }

    private void patroli()
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isWalk", true);
        animator.SetBool("isRun", false);

        if (!walkPointSet)
        {
            searchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Musuh sampai tujuan
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void kejar()
    {
        agent.SetDestination(player.position);
        animator.SetBool("isAttack", false);
        animator.SetBool("isWalk", false);
        animator.SetBool("isRun", true);
    }

    private void serang()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttack)
        {
            //Script Attack
            alreadyAttack = true;
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            Invoke(nameof(resetAttack), timeBetweenAttack);
        }
    }

    private void resetAttack()
    {
        alreadyAttack = false;
        animator.SetBool("isAttack", false);
    }
}
