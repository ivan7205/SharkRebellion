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

    public GameObject healthBarCanvas; // Referencia al Canvas
    public float dieAnimationDuration = 1f; // Duración de la animación de muerte

    private Transform player;
    private Animator animator;
    private bool isDying = false; // Para evitar múltiples llamadas

    void Start()
    {
        currentHealth = maxHealth;

        // Encontrar al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Obtener el Animator
        animator = GetComponent<Animator>();

        // Ocultar corazones al inicio
        HideHealth();
    }

    void Update()
    {
        // Verificar distancia al jugador
        if (player != null && !isDying)
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
        if (isDying) return; // No recibir más daño si ya está muriendo

        currentHealth -= amount;

        // Activar animación de daño (Damage)
        if (animator != null && currentHealth > 0)
        {
            animator.SetTrigger("Damage");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para manejar la muerte
    void Die()
    {
        isDying = true;

        // Activar animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Ocultar la barra de vida inmediatamente
        HideHealth();

        // Destruir el Canvas inmediatamente
        if (healthBarCanvas != null)
        {
            Destroy(healthBarCanvas);
        }

        // Destruir el enemigo después de que termine la animación
        Destroy(gameObject, dieAnimationDuration);
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

    // Gizmos para visualizar el rango de detección
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