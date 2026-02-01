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

    public Image portraitImage;
    public Sprite portrait;

    public EnemyHealth nearestEnemy;

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
        float closestEnemyDistance = Mathf.Infinity;
        nearestEnemy = null;

        EnemyHealth[] potentialTargets = FindObjectsOfType<EnemyHealth>();

        foreach (EnemyHealth currentEnemy in potentialTargets)
        {
            float distanceAway = (currentEnemy.transform.position - transform.position).sqrMagnitude;
            
            if (distanceAway < closestEnemyDistance)
            {
                closestEnemyDistance = distanceAway;
                nearestEnemy = currentEnemy;
            }
        }

        if (closestEnemyDistance <= 15*15)
        {
            HealthBarOn();
        }

        else
        {
            HealthBarOff();
        }
    }

    public void HealthBarOff()
    {
        portraitImage.enabled = false;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void HealthBarOn()
    {
        portraitImage.enabled = true;
        portraitImage.sprite = nearestEnemy.portrait;

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