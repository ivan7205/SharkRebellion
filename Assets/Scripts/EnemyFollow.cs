using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 1.5f;
    public float attackCooldown = 1.5f;

    private Transform player;
    private Animator animator;
    private float lastAttackTime = -999f;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;

                if (animator != null)
                {
                    animator.SetBool("Idle", false);
                }
            }
            else
            {
                if (animator != null)
                {
                    animator.SetBool("Idle", true);

                    if (Time.time >= lastAttackTime + attackCooldown)
                    {
                        animator.SetTrigger("Attack");
                        lastAttackTime = Time.time;
                    }
                }
            }

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

    public void DealDamage()
    {
        Debug.Log("DealDamage llamado en el jefe");

        // SIMPLIFICADO: Solo verificar distancia, no isAttacking
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            // Verificar que está en rango de ataque
            if (distance <= stopDistance * 1.5f) // Un poco más de margen
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
