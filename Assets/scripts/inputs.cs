using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class inputs : MonoBehaviour
{
    public playerspawner playerspawner;
    public Vector2 movement;
    public bool jumppressed;
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerspawner.PlayerInvert();
        }
    }
    public void Jump(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            jumppressed = true;
        }
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
        SceneManager.LoadScene(0);

    }
}
