using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startlife = 100; //This script is responsible for handling the health of the player and enemies.

    public bool destroyOnDeath = false; //This variable is responsible for determining whether the player or enemy should be destroyed when they die.

    private int _currentLife; //This variable is responsible for storing the current health of the player and enemies.
    private bool _isDead; //This variable is responsible for storing whether the player or enemy is dead or not.

    private void Awake()
    {
        _currentLife = startlife;
    }

    private void Init()
    {
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;

        if (destroyOnDeath)
        {
            Destroy(gameObject);
        }
    }
}
