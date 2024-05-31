using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10; // Damage dealt to the enemy per attack
    public float attackCooldown = 1f; // Time between attacks
    public GameObject weapon; // Reference to the weapon GameObject

    private float lastAttackTime;
    private Collider weaponCollider;

    void Start()
    {
        weaponCollider = weapon.GetComponent<Collider>();
        if (weaponCollider == null)
        {
            Debug.LogError("Weapon must have a collider attached.");
        }
        weaponCollider.enabled = false; // Disable the collider initially
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + attackCooldown) // Detect left mouse button click
        {
            Attack();
        }
    }

    void Attack()
    {
        // Enable the weapon collider for a short duration to simulate a swing
        StartCoroutine(SwingWeapon());

        // Update the time of the last attack
        lastAttackTime = Time.time;
    }

    System.Collections.IEnumerator SwingWeapon()
    {
        weaponCollider.enabled = true; // Enable the collider
        yield return new WaitForSeconds(0.1f); // Keep it enabled for a short duration
        weaponCollider.enabled = false; // Disable the collider
    }
}
