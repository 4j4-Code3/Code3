using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MagasinUI : MonoBehaviour
{
    public ListeItemsMagasin listeItems;
    public Inventaire inventaire;

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
            if(inventaire.debris >= item.prix)
            {
                cloneBouton.GetComponent<Button>().onClick.AddListener(() => Acheter());
                inventaire.debris -= item.prix;
            }
        }    
    }

    private void Acheter()
    {
        Debug.Log("letsgooo");
    }
}
