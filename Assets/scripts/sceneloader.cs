using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class sceneloader : MonoBehaviour
{
    public void scenechange()
    {
        SceneManager.LoadScene(1);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onquit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            quit();
        }
    }
    void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBGL
            Application.OpenURL("https:/itch.io"); 
        #else 
            Application.Quit();
        #endif 

    }
}
