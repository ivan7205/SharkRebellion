using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    // AÑADIDO: Referencias a la UI de este enemigo
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public float showHealthDistance = 15f;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;

        // AÑADIDO: Encontrar al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // AÑADIDO: Ocultar corazones al inicio
        UpdateHealthDisplay();
    }

    void Update()
    {
        // AÑADIDO: Verificar distancia al jugador
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= showHealthDistance)
            {
                ShowHealth();
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
        UpdateHealthDisplay(); // AÑADIDO: Actualizar display

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // AÑADIDO: Mostrar corazones
    void ShowHealth()
    {
        UpdateHealthDisplay();
    }

    // AÑADIDO: Ocultar corazones
    void HideHealth()
    {
        foreach (Image heart in hearts)
        {
            heart.enabled = false;
        }
    }

    // AÑADIDO: Actualizar display de vida
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