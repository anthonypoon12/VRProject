using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public class HealthBar : MonoBehaviour
// {
//     public Slider HealthSlider;
//     public float maxHealth = 100f;
//     public float health;
//     // Start is called before the first frame update
//     void Start()
//     {
//         health = maxHealth;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (HealthSlider.value != health)
//         {
//             HealthSlider.value = health;
//         }
//     }
// }

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public Enemyfollow enemyFollow;

    void Start()
    {
        // Assign the Enemyfollow script reference
        enemyFollow = GameObject.FindWithTag("Zombie").GetComponent<Enemyfollow>();
        HealthSlider.maxValue = enemyFollow.health;
    }

    void Update()
    {
        Debug.Log(HealthSlider);
        HealthSlider.value = enemyFollow.health;
    }
}
