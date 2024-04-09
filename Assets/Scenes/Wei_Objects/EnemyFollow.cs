using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemyfollow : MonoBehaviour, ITakeDamage
{
    public float speed = 3.0f;
    public float rotationSpeed = 1.0f;
    public Transform target;
    public float attackRange = 3f;
    public Animator animator;
    private float maxHealth = 100f;
    public float health;
    private float DamageToPlayer;
     public Slider HealthSlider;

    // variable for bullet collision
    // Update is called once per frame
    void Start(){
        health = maxHealth;
    }

    void Update()
    {
        //gets position of the player
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        // Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        //calculates the distance of the player vs zombie
        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);
        Vector3 targetDirection = targetPosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (health <= 0f)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
            Die();
            return;
        }

        if (distanceToPlayer <= attackRange)
        {
            // Player is close, switch to attack animation
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);

        }
        else
        {
            // Player is too far, switch to run animation
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            //moves the zombie towards the user
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);   

        }
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 hitPoint)
    {
        health -= weapon.GetDamage();
        HealthSlider.value = health;
        Debug.Log(health);
    }

    private void Die()
    {
        Destroy(gameObject); // Remove the zombie from the scene
    }
}