using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int damage = 10; //This script is responsible for handling the damage that the enemy will deal to the player.

    public Animator animator; //This script is responsible for the animator of the enemy.
    public string triggerAttack = "attack"; //This script is responsible for the trigger that makes the enemy attack in the animator.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name); //This line is responsible for logging the name of the object that the enemy collided with, which can be useful for debugging purposes.

        var Health = collision.gameObject.GetComponent<HealthBase>(); //This line is responsible for getting the HealthBase component of the object that the enemy collided with, which is necessary to apply damage to the player.

        //This line is responsible for applying damage to the player if the object that the enemy collided with has a HealthBase component. If the object does not have a HealthBase component, this line will do nothing.
        if (Health != null)
        {
            Health.Damage(damage);
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack); //This line is responsible for setting the trigger that makes the enemy attack in the animator, which will play the attack animation.
    }
}
