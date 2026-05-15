using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    void OnEnable()  // OnEnable en vez de Start
    {
        // Primero removemos listeners anteriores para no acumularlos
        slider.onValueChanged.RemoveListener(ChangeVolume);

        // Cargamos el valor SIN disparar el evento
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        slider.SetValueWithoutNotify(savedVolume); // No dispara onValueChanged
        AudioListener.volume = savedVolume;

        // Ahora sí añadimos el listener
        slider.onValueChanged.AddListener(ChangeVolume);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveListener(ChangeVolume);
        PlayerPrefs.Save(); // Garantiza que se guarde al cerrar Settings
    }

    void ChangeVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}
