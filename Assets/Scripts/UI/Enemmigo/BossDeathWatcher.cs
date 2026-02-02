using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathWatcher : MonoBehaviour
{
    public Animator animator; // referencia al Animator del boss
    public string deathTriggerName = "PitchgeonDeath"; // nombre del trigger de muerte
    private bool hasDied = false;

    void Update()
    {
        if (hasDied) return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PitchgeonDeath"))
        {
            hasDied = true;
            // Cambiar de escena justo cuando empieza la animación de muerte
            SceneManager.LoadScene("Ganaste"); // pon tu escena
        }
    }
}
