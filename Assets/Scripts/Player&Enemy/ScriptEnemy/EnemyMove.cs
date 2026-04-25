using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int damage = 10; //This script is responsible for handling the damage that the enemy will deal to the player.

    public Animator animator; //This script is responsible for the animator of the enemy.
    public string triggerAttack = "Attack"; //This script is responsible for the trigger that makes the enemy attack in the animator.
    public string triggerDeath = "Death"; //This script is responsible for the trigger that makes the enemy die in the animator.

    public HealthBase healthBase; //This script is responsible for the HealthBase component of the enemy, which is necessary to apply damage to the player.

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;  //This line is responsible for subscribing the OnEnemyKill method to the OnKill event of the HealthBase component, which will allow the enemy to perform certain actions when it is killed.
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation(); //This line is responsible for playing the death animation of the enemy when it is killed.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name); //This line is responsible for logging the name of the object that the enemy collided with, which can be useful for debugging purposes.

        var Health = collision.gameObject.GetComponent<HealthBase>(); //This line is responsible for getting the HealthBase component of the object that the enemy collided with, which is necessary to apply damage to the player.

        //This line is responsible for applying damage to the player if the object that the enemy collided with has a HealthBase component. If the object does not have a HealthBase component, this line will do nothing.
        if (Health != null)
        {
            Health.Damage(damage);
            PlayAttackAnimation(); //This line is responsible for playing the attack animation of the enemy when it collides with the player.
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack); //This line is responsible for setting the trigger that makes the enemy attack in the animator, which will play the attack animation.
    }
    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath); //This line is responsible for setting the trigger that makes the enemy die in the animator, which will play the death animation.
    }
}
