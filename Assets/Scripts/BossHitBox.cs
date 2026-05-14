using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            return; // evitar que se llame a sí mismo

        EnemyHealth health = other.GetComponent<EnemyHealth>();
        if (health == null && enemyHealth != null)
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
