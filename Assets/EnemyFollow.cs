using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollow : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform target;
    public float attackRange = 2f;
    public Animator animator;
    public float health = 100f;

    // variable for bullet collision


    // Update is called once per frame
    void Update()
    {
        //gets position of the player
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        //moves the zombie towards the user
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);   


        //calculates the distance of the player vs zombie
        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

        if (health <= 0f)
        {

            animator.SetBool("isDead", true);
            Die();
            return;
        }

        if (distanceToPlayer <= attackRange)
        {
            // Player is close, switch to attack animation
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            Debug.Log(animator.GetBool("isRunning"));
            Debug.Log(animator.GetBool("isAttacking"));
        }
        else
        {
            // Player is too far, switch to run animation
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            Debug.Log("Is running?: ");
            Debug.Log(animator.GetBool("isRunning"));
            Debug.Log(animator.GetBool("isAttacking"));
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Die()
    {
        // Play death animation or effects
        Destroy(gameObject); // Remove the zombie from the scene
    }
}
