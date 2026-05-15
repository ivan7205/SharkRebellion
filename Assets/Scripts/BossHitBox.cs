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
        Debug.Log("BossHitBox tocado por: " + other.gameObject.name + " tag: " + other.gameObject.tag);

        // Solo procesar balas, no otras cosas
        if (other.CompareTag("Bullet"))
        {
            if (enemyHealth != null)
                enemyHealth.TakeDamage(other.GetComponent<BulletDamage>()?.damage ?? 1);
        }
    }
}
