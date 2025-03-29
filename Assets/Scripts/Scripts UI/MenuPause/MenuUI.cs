using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}

