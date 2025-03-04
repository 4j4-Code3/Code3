using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InfosIcones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI texteDescription;
    public Item item;

    void Start()
    {
        texteDescription.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        texteDescription.text = item.description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        texteDescription.text = "";
    }
}
