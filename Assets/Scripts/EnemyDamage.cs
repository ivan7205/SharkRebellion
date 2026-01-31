using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //public JeffHealth playerHealth;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Intentamos buscar JeffHealth primero
        JeffHealth jeffHealth = collision.gameObject.GetComponent<JeffHealth>();
        if (jeffHealth != null)
        {
            jeffHealth.TakeDamage(damage);
            return; // ya aplicamos el daño, salimos
        }

        // Si no es Jeff, probamos VenomHealth
        VenomHealth venomHealth = collision.gameObject.GetComponent<VenomHealth>();
        if (venomHealth != null)
        {
            venomHealth.TakeDamage(damage);
            return;
        }

        // Si llegamos aquí, el Player no tiene ninguno de los dos
        Debug.LogWarning("El objeto Player no tiene ni JeffHealth ni VenomHealth!");
    }
}
