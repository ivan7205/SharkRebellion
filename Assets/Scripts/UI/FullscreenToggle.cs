using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    private int windowedWidth = 1280;
    private int windowedHeight = 720;

    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            && Input.GetKeyDown(KeyCode.F))
        {
            ToggleFullscreen();
        }
    }

    private void ToggleFullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(windowedWidth, windowedHeight, FullScreenMode.Windowed);
        }
        else
        {
            Resolution current = Screen.currentResolution;
            Screen.SetResolution(current.width, current.height, FullScreenMode.FullScreenWindow);
        }
    }
}
