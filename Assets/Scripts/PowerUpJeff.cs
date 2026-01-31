using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJeff : MonoBehaviour
{
    public int vialCount = 0;
    public int vialsNeeded = 5;

    [Header("Power Up")]
    public GameObject powerUpPlayerPrefab;

    public void AddVial()
    {
        vialCount++;

        if (vialCount >= vialsNeeded)
        {
            ActivatePowerUp();
        }
    }

    void ActivatePowerUp()
    {
        // Guardamos posición y rotación
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        // Instanciamos el nuevo player
        GameObject newPlayer = Instantiate(powerUpPlayerPrefab, pos, rot);

        // Opcional: pasarle datos
        // newPlayer.GetComponent<OtroScript>().vida = vida;

        // Destruimos el player normal
        Destroy(gameObject);
    }
}