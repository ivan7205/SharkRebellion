using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 6;

    public SpriteRenderer playerSr;
    public VenomMove playerMovement;
    public Animator animator;
    public Jump playerJump;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
            animator.SetTrigger("Idle");
            playerJump.enabled = false;
        }
    }
}
