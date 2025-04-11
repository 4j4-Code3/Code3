using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class InfosIcones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ItemData item;
    public NoteData noteData;

    public GameObject associatedNoteObject; 
    public GameObject description;

    void Start()
    {
        if (description == null)
        {
            description = GameObject.Find("Description");
        }
        description.GetComponent<TextMeshProUGUI>().text = "";
        

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.GetComponent<TextMeshProUGUI>().text = item.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (associatedNoteObject != null)
        {
            associatedNoteObject.SetActive(true);
        }
    }
}

