using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int maxHealth;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public float maxDetectDistance = 15f;

    public EnemyHealth nearestEnemy;
    public List<EnemyHealth> enemies = new List<EnemyHealth>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    public void FindClosestEnemy()
    {

        float closestDistance = Mathf.Infinity;
        nearestEnemy = null;

        foreach (EnemyHealth enemy in enemies)
        {
            if (enemy == null) continue;
            if (enemy.currentHealth <= 0) continue;

            float distance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && closestDistance <= maxDetectDistance * maxDetectDistance)
            HealthBarOn();
        else
            HealthBarOff();
    }


    public void HealthBarOff()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void HealthBarOn()
    {
        maxHealth = nearestEnemy.maxHealth;
        health = nearestEnemy.currentHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
                hearts[i].sprite = (i < health) ? fullHeart : emptyHeart;
            }
            else
            {
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }
}