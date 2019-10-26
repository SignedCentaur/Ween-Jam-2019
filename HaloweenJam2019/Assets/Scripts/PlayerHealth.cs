using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 10;
    public Image healthBar;
    float totalHealth;

    private void Start()
    {
        totalHealth = currentHealth;
    }

    public void Hurt(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthBar.fillAmount = (1 / totalHealth) * currentHealth;
    }
}
