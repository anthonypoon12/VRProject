using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Text healthDisplay;
    public GameObject deathScreen;
    public GameObject gun;
    private Pistol pistol;

    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay.text = currentHealth.ToString() + "/" + maxHealth.ToString();  // Update ammoDisplay.text
        pistol = gun.GetComponent<Pistol>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthDisplay.text = currentHealth.ToString() + "/" + maxHealth.ToString();  // Update ammoDisplay.text
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathScreen.SetActive(true);
        pistol.EmptyAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
