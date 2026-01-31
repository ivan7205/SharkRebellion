using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject jeff;
    public GameObject venom;

    [Header("Vials")]
    public int vialCount = 0;       // contador global
    public int vialsNeeded = 5;     // viales necesarios para transformarse

    private void Start()
    {
        // Solo Jeff activo al inicio
        jeff.SetActive(true);
        venom.SetActive(false);
    }

    // Este método lo llamarán los viales al ser recogidos
    public void CollectVial()
    {
        vialCount++;
        Debug.Log("Viales recogidos: " + vialCount);

        if (vialCount >= vialsNeeded)
        {
            ActivateVenom();
        }
    }

    private void ActivateVenom()
    {
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
