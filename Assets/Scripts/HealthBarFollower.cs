using UnityEngine;

public class HealthBarFollower : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, 0); // Altura sobre el enemigo
    public Transform specificEnemy; // Asignar manualmente si quieres un enemigo específico

    private Transform enemy; // El enemigo al que seguir

    void Start()
    {
        // Si se asignó un enemigo específico manualmente, usar ese
        if (specificEnemy != null)
        {
            enemy = specificEnemy;
        }
        else
        {
            // Buscar el enemigo más cercano con tag "Enemy"
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                float closestDistance = Mathf.Infinity;
                foreach (GameObject enemyObj in enemies)
                {
                    float distance = Vector3.Distance(transform.position, enemyObj.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        enemy = enemyObj.transform;
                    }
                }
            }
            else
            {
                Debug.LogWarning("No se encontró ningún objeto con tag 'Enemy'");
            }
        }
    }

    void LateUpdate()
    {
        if (enemy != null)
        {
            // Seguir la posición del enemigo con offset
            transform.position = enemy.position + offset;

            // SIEMPRE mantener rotación en 0
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
