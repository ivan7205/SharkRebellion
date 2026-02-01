using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 6;

    public SpriteRenderer playerSr;
    public Move playerMovement;
    public Animator animator;
    public Jump playerJump;

    [Header("Audio")]
    public AudioSource audioSource; // Asignar en Inspector
    public AudioClip damageSound;   // Asignar en Inspector

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        if (health <= 0) return; // Evitamos que se siga llamando si ya murió

        health -= amount;

        // Reproducir sonido al recibir daño
        if (audioSource != null && damageSound != null)
            audioSource.PlayOneShot(damageSound);

        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
            animator.SetTrigger("Die");
            playerJump.enabled = false;
        }
    }
}

