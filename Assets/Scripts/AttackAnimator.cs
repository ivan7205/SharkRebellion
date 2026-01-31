using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator; // Arrastrar aquí el Animator del personaje

    [Header("Input")]
    public KeyCode attackKey = KeyCode.Space; // Tecla de ataque

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(attackKey))
        {
            // Debug para asegurarnos de que se detecta la tecla
            Debug.Log("Ataque activado");

            // Disparamos el Trigger del Animator
            animator.SetTrigger("AttackTrigger");
        }
    }
}
