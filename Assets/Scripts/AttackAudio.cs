using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Attack Sounds")]
    public AudioClip Jeff_Attack;
    public AudioClip Jeff_Shoot_Short;
    public AudioClip Jeff_Shoot_Long;

    public void PlayAttackJ()
    {
        audioSource.PlayOneShot(Jeff_Attack);
    }

    public void PlayAttackK()
    {
        audioSource.PlayOneShot(Jeff_Shoot_Short);
    }

    public void PlayAttackL()
    {
        audioSource.PlayOneShot(Jeff_Shoot_Long);
    }
}
