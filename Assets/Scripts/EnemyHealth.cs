using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    // Referencias a la UI de este enemigo
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public float showHealthDistance = 15f;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;

        // Encontrar al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Ocultar corazones al inicio
        HideHealth();
    }

    void Update()
    {
        // Verificar distancia al jugador
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= showHealthDistance)
            {
                UpdateHealthDisplay();
            }
            else
            {
                HideHealth();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Ocultar corazones
    void HideHealth()
    {
        foreach (Image heart in hearts)
        {
            heart.enabled = false;
        }
    }

    // Actualizar display de vida
    void UpdateHealthDisplay()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
                hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
