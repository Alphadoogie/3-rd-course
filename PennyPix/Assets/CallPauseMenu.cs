using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsPaused = false;
    public static bool exInput = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || exInput)
        {
            if (!IsPaused)
            {
                PauseMenu.SetActive(true);
                IsPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                PauseMenu.SetActive(false);
                IsPaused = false;
                Time.timeScale = 1;
            }
            exInput = false;
        }
    }
}
