using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class MagasinUI : MonoBehaviour
{
    public ListeItemsMagasin listeItems;
    public Inventaire inventaire;

    public GameObject boutonPrefab;
    public GameObject parentBouton;

    public StatsJoueur statsJoueur;
    

    public bool magasinUIActif = false;

// Crée un bouton pour chaque item du magasin
    void Awake()
    {
        foreach(ItemDataMagasin item in listeItems.itemsAVendre)
        {      
            GameObject cloneBouton = Instantiate(boutonPrefab, parentBouton.transform);
            cloneBouton.GetComponent<InfosBoutons>().nomItem.text = item.nom;
            cloneBouton.GetComponent<InfosBoutons>().prixItem.text = item.prix.ToString();
            cloneBouton.GetComponent<Button>().onClick.AddListener(() => Acheter(item, cloneBouton));
            
        }    
    }

// Permet d'acheter les items du magasin
    public void Acheter(ItemDataMagasin item, GameObject bouton)
    {
        if(inventaire.debris >= item.prix)
        {
            switch(item.type)
            {
                case ItemType.Radiation:
                statsJoueur.maxRadiation += item.bonus;
                break;
                case ItemType.SeringueEfficacite:
                break;
                case ItemType.SeringueMax:
                break;
                case ItemType.Degats:
                break;
            }

            inventaire.debris -= item.prix;
            Destroy(bouton);

            listeItems.itemsAVendre.Remove(item);
            inventaire.items.Add(item);
        }
    }
}
