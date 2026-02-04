using UnityEngine;

public class AppExitHandler : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Saliendo de la aplicación...");
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
