using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangementPagesMagasinPlus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public MagasinUI magasinUI;
    private Image image;
    private Color couleur;
    public Curseur curseur;

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
        Cursor.SetCursor(curseur.imageCurseurActif, Vector2.zero, CursorMode.Auto);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        couleur.a = 1;
        image.color = couleur;
        Cursor.SetCursor(curseur.imageCurseurDefaut, Vector2.zero, CursorMode.Auto);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        magasinUI.PageSuivante();
    }
}
