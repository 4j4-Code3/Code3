using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class InfosIcones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Gère les icônes qui apparaissent dans l'inventaire
    public ItemData item;
    public NoteData note;
    public GameObject description;


    void Start()
    {
        description = GameObject.Find("Description");
        description.GetComponent<TextMeshProUGUI>().text = "";

        if(note != null)
        {
            note.note = GameObject.Find("Note1");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.GetComponent<TextMeshProUGUI>().text = item.description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        description.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {

        if(note != null)
        {
            note.note.SetActive(true);
        }
        return;
    }
}
