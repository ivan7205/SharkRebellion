using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusica : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic();
        }
    }
}
