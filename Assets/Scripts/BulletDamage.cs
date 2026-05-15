using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletDamage : MonoBehaviour
{
    public int damage = 2;
    private bool hasHit = false;
    public Vector2 moveDirection;
    public float moveSpeed;

    void Update()
    {
      transform.position += (Vector3)(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bala tocó: " + collision.gameObject.name + " tag: " + collision.gameObject.tag + " hasHit: " + hasHit);

        if (hasHit) return;

        if (collision.CompareTag("Player") ||
        collision.CompareTag("Untagged") ||
        collision.CompareTag("Boss") || 
        collision.CompareTag("Bullet"))
            return;

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

            if (enemy == null)
            {
                // Es el HitBox hijo del jefe, BossHitBox gestiona el daño
                return;
            }

            // Es un enemigo normal con EnemyHealth directamente en él
            hasHit = true;
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
