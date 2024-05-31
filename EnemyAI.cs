using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's position
    public float moveSpeed = 5f; // Speed at which the enemy moves
    public float stoppingDistance = 5f; // Distance at which the enemy stops following the player
    public float attackDistance = 2f; // Distance at which the enemy starts attacking the player
    public float attackCooldown = 1f; // Time between attacks
    public int attackDamage = 10; // Damage dealt to the player per attack
    public int maxHealth = 50; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    private NavMeshAgent navMeshAgent;
    private float lastAttackTime;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = -attackCooldown; // Ensure the enemy can attack immediately
        currentHealth = maxHealth; // Initialize the enemy's health

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player GameObject is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            // Player is out of range, stop following
            navMeshAgent.isStopped = true;
        }
        else if (distanceToPlayer <= stoppingDistance && distanceToPlayer > attackDistance)
        {
            // Player is within following range but out of attack range, follow the player
            FollowPlayer();
        }
        else if (distanceToPlayer <= attackDistance)
        {
            // Player is within attack range, stop and attack
            navMeshAgent.isStopped = true;
            AttackPlayer();
        }
    }

    void FollowPlayer()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        if (Time.time > lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }

            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
