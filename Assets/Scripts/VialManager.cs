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
    public int vialCount = 0;
    public int vialsNeeded = 5;

    [Header("Venom Duration")]
    public float venomDuration = 10f; // segundos que dura la forma Venom

    [Header("UI")]
    public Slider vialSlider;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip transformSound;

    [Header("Camera")]
    public CamaraIndependiente2D camaraScript;

    private bool venomReady = false;  // poder disponible pero no activado
    private bool venomActive = false; // venom ya está activo

    private void Start()
    {
        jeff.SetActive(true);
        venom.SetActive(false);

        if (vialSlider != null)
        {
            vialSlider.minValue = 0;
            vialSlider.maxValue = vialsNeeded;
            vialSlider.value = vialCount;
        }

        if (camaraScript == null)
            camaraScript = Camera.main.GetComponent<CamaraIndependiente2D>();
    }

    private void Update()
    {
        // Solo activar si el poder está listo y se presiona Space
        if (venomReady && !venomActive && Input.GetKeyDown(KeyCode.Space))
        {
            ActivateVenom();
        }
    }

    public void CollectVial()
    {
        vialCount++;
        Debug.Log("Viales recogidos: " + vialCount);

        if (vialSlider != null)
            vialSlider.value = vialCount;

        if (vialCount >= vialsNeeded)
        {
            venomReady = true;
            Debug.Log("¡Poder Venom listo! Presiona Space para activar.");
        }
    }

    private void ActivateVenom()
    {
        venomReady = false;
        venomActive = true;

        if (audioSource != null && transformSound != null)
            audioSource.PlayOneShot(transformSound);

        Vector3 jeffPos = jeff.transform.position;
        Quaternion jeffRot = jeff.transform.rotation;

        jeff.SetActive(false);
        venom.SetActive(true);

        venom.transform.position = jeffPos;
        venom.transform.rotation = jeffRot;

        if (camaraScript != null)
            camaraScript.CambiarObjetivo(venom.transform);

        Debug.Log("¡Jeff se ha transformado en Venom!");

        StartCoroutine(VenomTimer());
    }

    private IEnumerator VenomTimer()
    {
        float elapsed = 0f;

        while (elapsed < venomDuration)
        {
            elapsed += Time.deltaTime;

            // La barra drena progresivamente de lleno a 0
            if (vialSlider != null)
                vialSlider.value = Mathf.Lerp(vialsNeeded, 0, elapsed / venomDuration);

            yield return null;
        }

        DeactivateVenom();
    }

    private void DeactivateVenom()
    {
        venomActive = false;
        vialCount = 0;

        // Resetear barra
        if (vialSlider != null)
            vialSlider.value = 0;

        Vector3 venomPos = venom.transform.position;
        Quaternion venomRot = venom.transform.rotation;

        venom.SetActive(false);
        jeff.SetActive(true);

        jeff.transform.position = venomPos;
        jeff.transform.rotation = venomRot;

        if (camaraScript != null)
            camaraScript.CambiarObjetivo(jeff.transform);

        Debug.Log("Venom se ha agotado, Jeff ha vuelto.");
    }
}