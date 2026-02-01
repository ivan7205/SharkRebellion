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
            // Calcular distancia en X (horizontal)
            float distanceX = Mathf.Abs(player.position.x - transform.position.x);

            if (distanceX <= showHealthDistance)
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

    // AÑADIDO: Gizmos para visualizar el rango de detección
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Línea izquierda
        Vector3 leftPoint = transform.position + Vector3.left * showHealthDistance;
        Gizmos.DrawLine(transform.position, leftPoint);
        Gizmos.DrawWireSphere(leftPoint, 0.3f);

        // Línea derecha
        Vector3 rightPoint = transform.position + Vector3.right * showHealthDistance;
        Gizmos.DrawLine(transform.position, rightPoint);
        Gizmos.DrawWireSphere(rightPoint, 0.3f);

        // Línea completa mostrando el rango total
        Gizmos.color = Color.green;
        Gizmos.DrawLine(leftPoint, rightPoint);
    }
}
