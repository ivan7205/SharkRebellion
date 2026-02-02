using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffAttack : MonoBehaviour
{
    public Collider2D attackCollider;
    public int damage = 1;
    public Animator animator;
    public AttackAudio attackAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        // Disparo corto
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("ShootShort");
            // QUITADO: attackAudio.PlayShootShort(); 
        }

        // Disparo largo
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("ShootLong 0");
            // QUITADO: attackAudio.PlayShootLong();
        }
    }

    void Attack()
    {
        // Aquí lanzas la animación
        GetComponent<Animator>().SetTrigger("Attack");
        // Activamos la hitbox solo un momento
        StartCoroutine(AttackRoutine());
    }

    System.Collections.IEnumerator AttackRoutine()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.2f); // duración del golpe
        attackCollider.enabled = false;
    }

    public void EnableAttack()
    {
        Debug.Log("HITBOX ON");
        attackCollider.enabled = true;
    }

    public void DisableAttack()
    {
        Debug.Log("HITBOX OFF");
        attackCollider.enabled = false;
    }
}