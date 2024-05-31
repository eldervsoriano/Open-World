using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public int attackDamage = 10; // Damage dealt to the enemy per attack

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(attackDamage);
            }
        }
    }
}
