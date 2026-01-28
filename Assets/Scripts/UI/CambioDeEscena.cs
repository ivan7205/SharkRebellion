using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            End(); // Ejecutando la función End
        }
    }
    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //Carga una escena
    }
    public void End()
    {
        Debug.Log("Se termino");
        Application.Quit();
    }
}
