using UnityEngine;

public class FullScreenController : MonoBehaviour
{
    void Start()
    {
        // Set the game to run in full screen mode when the game starts
        SetFullScreen();
    }

    void Update()
    {
        // Check for user input to toggle full screen
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFullScreen();
        }
    }

    void SetFullScreen()
    {
        // Set the game to run in full screen mode
        Screen.fullScreen = true;
    }

    void ToggleFullScreen()
    {
        // Toggle between full screen and windowed mode
        Screen.fullScreen = !Screen.fullScreen;
    }
}
