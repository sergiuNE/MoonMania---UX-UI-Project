using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit button clicked. Quitting the game...");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
