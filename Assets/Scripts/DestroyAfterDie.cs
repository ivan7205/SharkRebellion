using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDie : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
