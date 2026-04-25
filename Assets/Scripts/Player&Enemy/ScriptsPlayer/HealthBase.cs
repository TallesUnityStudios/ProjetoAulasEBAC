using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill; //This event is responsible for notifying when the player or enemy is killed.

    public int startlife = 100; //This script is responsible for handling the health of the player and enemies.

    public bool destroyOnDeath = false; //This variable is responsible for determining whether the player or enemy should be destroyed when they die.

    private int _currentLife; //This variable is responsible for storing the current health of the player and enemies.
    private bool _isDead; //This variable is responsible for storing whether the player or enemy is dead or not.

    [SerializeField]private FlashColor _flashColor; //This variable is responsible for storing the FlashColor component of the player and enemies.

    private void Awake()
    {
        _currentLife = startlife;
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }   
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

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Die()
    {
        _isDead = true;

        if (destroyOnDeath)
        {
            Destroy(gameObject);
        }
        OnKill?.Invoke();
    }
}
