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

    [Header("Volume Control")]
    [Range(0f, 1f)]
    public float volume = 1f; // valor por defecto


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
        PlaySound(Jeff_Attack);
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
   
    // Método que conectará el slider
    public void SetVolume(float value)
    {
        volume = value;
        if (audioSource != null)
            audioSource.volume = volume;
    }
}
