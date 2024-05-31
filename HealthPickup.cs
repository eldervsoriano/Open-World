using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 10;  // Amount of health to add

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(healthAmount);
            Destroy(gameObject);  // Destroy the health pickup object after it has been used
        }
    }
}
