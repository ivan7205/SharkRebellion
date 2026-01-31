using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararMusica : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }
}
