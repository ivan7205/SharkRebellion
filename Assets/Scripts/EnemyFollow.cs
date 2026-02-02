using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float stopDistance = 1.5f;

    [Header("Combat Settings")]
    public float attackCooldown = 1.5f;
    public int maxHealth = 3;

    private Transform player;
    private Animator animator;
    private float lastAttackTime = -999f;
    private int currentHealth;
    private bool isDead = false;
    private bool isTakingDamage = false;
    private bool isAttacking = false; // ← NUEVA VARIABLE

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // No hacer nada si está muerto, recibiendo daño o atacando
        if (isDead || isTakingDamage || isAttacking)
            return;

        if (player != null)
        {
            // Calcular distancia solo en el eje X (horizontal)
            float distanceX = Mathf.Abs(player.position.x - transform.position.x);

            if (distanceX > stopDistance)
            {
                // CAMINANDO - se mueve hacia el jugador
                float direction = Mathf.Sign(player.position.x - transform.position.x);
                transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

                if (animator != null)
                {
                    animator.SetBool("Idle", false); // Caminar
                }
            }
            else
            {
                // QUIETO - está en rango de ataque
                if (animator != null)
                {
                    animator.SetBool("Idle", true); // Idle

                    if (Time.time >= lastAttackTime + attackCooldown)
                    {
                        StartCoroutine(AttackRoutine());
                    }
                }
            }

            // Voltear según posición del jugador
            if (player.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;

        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        lastAttackTime = Time.time;

        // Esperar a que termine la animación de ataque
        // Ajusta según la duración de tu animación
        yield return new WaitForSeconds(1f);

        isAttacking = false;

        // CRÍTICO: Recalcular el estado después del ataque
        if (player != null && !isDead)
        {
            float distanceX = Mathf.Abs(player.position.x - transform.position.x);

            if (distanceX > stopDistance)
            {
                // Si el jugador se alejó durante el ataque, volver a caminar
                if (animator != null)
                {
                    animator.SetBool("Idle", false);
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead || isTakingDamage)
            return;

        currentHealth -= damage;
        Debug.Log("Enemigo recibió " + damage + " de daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageAnimation());
        }
    }

    private IEnumerator DamageAnimation()
    {
        isTakingDamage = true;

        if (animator != null)
        {
            animator.SetTrigger("Damage");
        }

        yield return new WaitForSeconds(0.5f);

        isTakingDamage = false;

        // CRÍTICO: Recalcular el estado después del daño
        if (player != null && !isDead)
        {
            float distanceX = Mathf.Abs(player.position.x - transform.position.x);

            if (distanceX > stopDistance)
            {
                // Si está lejos, asegurarse de volver a caminar
                if (animator != null)
                {
                    animator.SetBool("Idle", false);
                }
            }
            else
            {
                // Si está cerca, volver a idle
                if (animator != null)
                {
                    animator.SetBool("Idle", true);
                }
            }
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Enemigo murió");

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        this.enabled = false;
        Destroy(gameObject, 2f);
    }

    public void DealDamage()
    {
        if (player != null && !isDead)
        {
            float distanceX = Mathf.Abs(player.position.x - transform.position.x);

            if (distanceX <= stopDistance * 1.5f)
            {
                JeffHealth jeffHealth = player.GetComponent<JeffHealth>();
                if (jeffHealth != null)
                {
                    jeffHealth.TakeDamage(1);
                    return;
                }

                VenomHealth venomHealth = player.GetComponent<VenomHealth>();
                if (venomHealth != null)
                {
                    venomHealth.TakeDamage(1);
                }
            }
        }
    }
}
