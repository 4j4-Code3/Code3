using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MagasinUI : MonoBehaviour
{
    public ListeItems listeItems;

    public GameObject boutonPrefab;
    public GameObject parentBouton;

    public bool magasinUIActif = false;

    void Awake()
    {
        foreach(Item item in listeItems.itemsAVendre)
        {      
            GameObject cloneBouton = Instantiate(boutonPrefab, parentBouton.transform);
            cloneBouton.GetComponent<InfosBoutons>().nomItem.text = item.nom;
            cloneBouton.GetComponent<InfosBoutons>().prixItem.text = item.prix.ToString();
            cloneBouton.GetComponent<Button>().onClick.AddListener(() => Selecteur());
        }    
    }

    private void Selecteur()
    {
        Debug.Log("alo");
    }
}
