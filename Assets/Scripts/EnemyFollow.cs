using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 1f; // Distancia a la que se detiene

    private Transform player;

    void Start()
    {
        // Encontrar al jugador por tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calcular distancia al jugador
            float distance = Vector3.Distance(transform.position, player.position);

            // Si está lejos, moverse hacia el jugador
            if (distance > stopDistance)
            {
                // Dirección hacia el jugador
                Vector3 direction = (player.position - transform.position).normalized;

                // Mover al enemigo
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Mirar hacia el jugador (voltear sprite)
                if (player.position.x < transform.position.x)
                {
                    // Jugador está a la izquierda - voltear sprite
                    transform.localScale = new Vector3(0.47f, 0.47f, 0.47f);
                }

                else
                {
                    // Jugador está a la derecha - sprite normal
                    transform.localScale = new Vector3(-0.47f, 0.47f, 0.47f);
                }
            }
        }
    }
}