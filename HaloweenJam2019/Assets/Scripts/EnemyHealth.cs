﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 2;
    float totalHealth;

    private void Start()
    {
        totalHealth = currentHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth --;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
