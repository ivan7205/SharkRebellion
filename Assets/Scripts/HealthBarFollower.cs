using UnityEngine;

public class HealthBarFollower : MonoBehaviour
{
    public Transform enemy; // Asignar el enemigo manualmente en el Inspector
    public Vector3 offset = new Vector3(0, 2, 0); // Altura sobre el enemigo

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
