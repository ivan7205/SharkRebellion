using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pop : MonoBehaviour
{
    public float popScale = 1.2f;  // cuánto se agranda
    public float speed = 10f;      // velocidad de la animación

    private Vector3 originalScale;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(transform, originalScale * popScale, 0.1f));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(transform, originalScale, 0.1f));
    }

    System.Collections.IEnumerator ScaleTo(Transform target, Vector3 targetScale, float duration)
    {
        Vector3 startScale = target.localScale;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime; // unscaled para que no dependa del timeScale
            target.localScale = Vector3.Lerp(startScale, targetScale, t / duration);
            yield return null;
        }

        target.localScale = targetScale;
    }
}
