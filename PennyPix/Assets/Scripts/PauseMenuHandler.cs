using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    public void Resume()
    {
        CallPauseMenu.exInput = true;

    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}