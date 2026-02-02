using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeffHealth : MonoBehaviour
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

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return; // Evitamos que se siga llamando si ya murió

        health -= amount;

        // Reproducir sonido al recibir daño
        if (audioSource != null && damageSound != null)
            audioSource.PlayOneShot(damageSound);

        // Activar animación de recibir daño
        if (animator != null)
            animator.SetTrigger("Damage");

        if (health <= 0)
        {
            Die();
        }
        void Die()
        {
            isDead = true;
            playerMovement.enabled = false;
            playerJump.enabled = false;
            animator.SetTrigger("Die"); // esto dispara la animación
        }
    }

    
    public void OnDeathAnimationEnd()
    {
        Debug.Log("Animación de muerte terminada");
        SceneManager.LoadScene("Loooser");
    }

}
