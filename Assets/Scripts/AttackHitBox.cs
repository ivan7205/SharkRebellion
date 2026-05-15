using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Detectar cajas y simular que una bala las golpea
        if (other.CompareTag("Box"))
        {
            // Crear un objeto temporal con tag Bullet para activar el ConditionArea
            GameObject fakeHit = new GameObject("FakeHit");
            fakeHit.tag = "Bullet";
            fakeHit.transform.position = other.transform.position;
            BoxCollider2D col = fakeHit.AddComponent<BoxCollider2D>();
            col.isTrigger = true;
            Rigidbody2D rb = fakeHit.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            Destroy(fakeHit, 0.1f);
        }
    }
}
