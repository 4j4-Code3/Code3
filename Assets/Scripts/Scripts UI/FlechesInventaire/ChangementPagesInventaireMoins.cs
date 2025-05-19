using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YourScriptName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventaireUI inventaireUI;
    private Image image;
    private Color couleur;

    // Gère le changement de page vers la page précédente
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        couleur = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        couleur.a = 0;
        image.color = couleur;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        couleur.a = 1;
        image.color = couleur;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventaireUI.PagePrecedente();
    }
}
