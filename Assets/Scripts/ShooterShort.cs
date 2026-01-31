using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShort : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Bullet")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}
