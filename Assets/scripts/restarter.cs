using UnityEngine;
using UnityEngine.SceneManagement;

public class restarter : MonoBehaviour
{
    public bool isrestarting;
    public void restart()
    {
        Invoke(nameof(realrestart), 0.9f);
        isrestarting = true;
    }
    void realrestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
