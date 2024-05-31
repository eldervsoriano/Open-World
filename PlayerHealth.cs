using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI currentHealthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
        Debug.Log("Health added. Current health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
        Debug.Log("Player took damage. Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        currentHealthText.text = currentHealth.ToString();
    }

    void Die()
    {
        Debug.Log("Player died.");
        ChangeScene("GameOverScene");
    }

    void ChangeScene(string sceneName)
    {
        Cursor.visible = true; // Ensure the cursor is visible
        Cursor.lockState = CursorLockMode.None; // Ensure the cursor is unlocked
        SceneManager.LoadScene(sceneName);
    }
}
