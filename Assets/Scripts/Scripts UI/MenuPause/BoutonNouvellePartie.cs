using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoutonNouvellePartie : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GestionnaireSauvegardes.instance.NouvellePartie();
    }
}

