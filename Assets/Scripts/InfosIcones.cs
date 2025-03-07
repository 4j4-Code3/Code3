using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InfosIcones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public GameObject description;

    void Start()
    {
        description = GameObject.Find("Description");
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
}
