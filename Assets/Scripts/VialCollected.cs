using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VialCollected : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Avisamos al Player
            collision.GetComponent<PowerUpJeff>()?.AddVial();


            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 1f);
        }
    }
}

