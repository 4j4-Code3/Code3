using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangementPagesMagasinPlus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public MagasinUI magasinUI;
    private Image image;
    private Color couleur;

    // Gère le changement de page vers la page suivante
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
        magasinUI.PageSuivante();
    }
}
