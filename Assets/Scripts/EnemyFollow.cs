using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 1f;

    private Transform player;
    private Animator animator;
    public Canvas healthBarCanvas; // AÑADIDO: Referencia al Canvas

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        animator = GetComponent<Animator>();

        // AÑADIDO: Buscar el Canvas automáticamente si no está asignado
        if (healthBarCanvas == null)
        {
            healthBarCanvas = GetComponentInChildren<Canvas>();
        }
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
                }
            }

            // Voltear usando rotación en Y
            if (player.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            // AÑADIDO: LateUpdate para forzar rotación del Canvas DESPUÉS de todo
            void LateUpdate()
            {
                if (healthBarCanvas != null)
                {
                    healthBarCanvas.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
}
     