using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VialManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject jeff;
    public GameObject venom;

    [Header("Vials")]
    public int vialCount = 0;       // contador global
    public int vialsNeeded = 5;     // viales necesarios para transformarse

    [Header("UI")]
    public Slider vialSlider;  // arrastra aquí el Slider de la UI

    [Header("Audio")]
    public AudioSource audioSource; // Asignar en Inspector
    public AudioClip transformSound; // Sonido al transformarse

    private void Start()
    {
        // Solo Jeff activo al inicio
        jeff.SetActive(true);
        venom.SetActive(false);

        // Configuramos el slider
        if (vialSlider != null)
        {
            vialSlider.minValue = 0;
            vialSlider.maxValue = vialsNeeded;
            vialSlider.value = vialCount;
        }
    }

    // Este método lo llamarán los viales al ser recogidos
    public void CollectVial()
    {
        vialCount++;
        Debug.Log("Viales recogidos: " + vialCount);

        if (vialSlider != null)
        {
            vialSlider.value = vialCount;
            Debug.Log("Slider actualizado a: " + vialSlider.value);
        }

        //Activa el Venom si alcanzamos el limite
        if (vialCount >= vialsNeeded)
        {
            ActivateVenom();
        }
    }

    private void ActivateVenom()
    {
        // Sonido de transformación
        if (audioSource != null && transformSound != null)
        {
            audioSource.PlayOneShot(transformSound);
        }

        // Guardar la posición y rotación actual de Jeff

        Vector3 jeffPos = jeff.transform.position;
        Quaternion jeffRot = jeff.transform.rotation;
        jeff.SetActive(false);
        venom.SetActive(true);

        // 3Poner a Venom exactamente en la posición y rotación de Jeff
        venom.transform.position = jeffPos;
        venom.transform.rotation = jeffRot;

        Debug.Log("¡Jeff se ha transformado en Venom!");
    }
}
