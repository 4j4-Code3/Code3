using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUI : MonoBehaviour
{
    private bool pause = false;

    public GameObject menuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        menuPause.SetActive(pause);

        if(pause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

