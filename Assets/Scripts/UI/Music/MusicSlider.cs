using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        // Inicializar el slider con el valor guardado
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Añadir listener para cambios en tiempo real
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(value);
        }
    }
}
