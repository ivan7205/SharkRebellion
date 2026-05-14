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
        if (hasHit) return;

        if (collision.CompareTag("Player") ||
            collision.CompareTag("PlayerAttack") ||
            collision.CompareTag("Untagged"))
            return;

        if (collision.CompareTag("Enemy"))
        {
            hasHit = true;
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>()
                             ?? collision.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
