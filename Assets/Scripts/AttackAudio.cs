using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Attack Sounds")]
    public AudioClip Jeff_Attack;
    public AudioClip Jeff_Shoot_Short;
    public AudioClip Jeff_Shoot_Long;
    public AudioClip Jeff_Venom_Jump;
    public AudioClip Jeff_Die;

    public void PlayJump()
    {
        PlaySound(Jeff_Venom_Jump);
    }
    public void PlayDeath()
    {
        PlaySound(Jeff_Die);
    }
    
    public void PlayAttackJ()
    {
        audioSource.PlayOneShot(Jeff_Attack);
    }

    /*public void PlayAttackK()
    {
        audioSource.PlayOneShot(Jeff_Shoot_Short);
    }

    public void PlayAttackL()
    {
        audioSource.PlayOneShot(Jeff_Shoot_Long);
    }*/

    public void PlayShootShort()
    {
        PlaySound(Jeff_Shoot_Short);
    }

    public void PlayShootLong()
    {
        PlaySound(Jeff_Shoot_Long);
    }


    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }
}
