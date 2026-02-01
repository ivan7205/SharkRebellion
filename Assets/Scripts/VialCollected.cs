using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactivar sprite del vial
            GetComponent<SpriteRenderer>().enabled = false;
            if (transform.childCount > 0)
                transform.GetChild(0).gameObject.SetActive(true);

            // Llamamos al manager
            VialManager manager = FindObjectOfType<VialManager>();
            if (manager != null)
            {
                manager.CollectVial();
            }

            // Destruir el vial
            Destroy(gameObject, 0.1f);
        }
    }
}
