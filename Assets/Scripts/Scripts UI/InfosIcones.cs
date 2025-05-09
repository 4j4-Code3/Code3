using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InfosIcones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Gère les icônes qui apparaissent dans l'inventaire
    public ItemData item;
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
