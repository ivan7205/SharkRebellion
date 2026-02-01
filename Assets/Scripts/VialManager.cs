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

    [Header("Camera")]
    public CamaraIndependiente2D camaraScript; // Referencia al script de la cámara

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

        // Si no se asignó la cámara manualmente, buscarla automáticamente
        if (camaraScript == null)
        {
            camaraScript = Camera.main.GetComponent<CamaraIndependiente2D>();

            if (camaraScript == null)
            {
                Debug.LogWarning("No se encontró el script CamaraIndependiente2D en la Main Camera");
            }
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

        // Poner a Venom exactamente en la posición y rotación de Jeff
        venom.transform.position = jeffPos;
        venom.transform.rotation = jeffRot;

        // CAMBIAR EL OBJETIVO DE LA CÁMARA A VENOM
        if (camaraScript != null)
        {
            camaraScript.CambiarObjetivo(venom.transform);
            Debug.Log("Cámara ahora sigue a Venom");
        }
        else
        {
            Debug.LogWarning("No se pudo cambiar el objetivo de la cámara. Verifica que 'camaraScript' esté asignado.");
        }

        Debug.Log("¡Jeff se ha transformado en Venom!");
    }
}