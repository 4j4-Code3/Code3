using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class MagasinUI : MonoBehaviour
{
    public ListeItemsMagasin listeItems;
    public Inventaire inventaire;
    
    public GameObject boutonPrefab;
    public GameObject parentBouton;
    
    public StatsJoueur statsJoueur;
    
    public bool magasinUIActif = false;
    private int maxItemsParPages = 4;
    public int numeroPage = 0;
    private List<GameObject> boutonsActifs = new List<GameObject>();

    void Awake()
    {
        AfficherItems();
    }

    void AfficherItems()
    {
        DetruireItems();
        
        int debutIndex = numeroPage * maxItemsParPages;
        int finIndex = Mathf.Min(debutIndex + maxItemsParPages, listeItems.itemsAVendre.Count);

        for (int i = debutIndex; i < finIndex; i++)
        {
            ItemDataMagasin item = (ItemDataMagasin)listeItems.itemsAVendre[i];
            GameObject cloneBouton = Instantiate(boutonPrefab, parentBouton.transform);
            cloneBouton.GetComponent<InfosBoutons>().nomItem.text = item.nom;
            cloneBouton.GetComponent<InfosBoutons>().prixItem.text = item.prix.ToString();
            cloneBouton.GetComponent<Button>().onClick.AddListener(() => Acheter(item, cloneBouton));
            
            boutonsActifs.Add(cloneBouton);
        }
    }

    void DetruireItems()
    {
        foreach (GameObject bouton in boutonsActifs)
        {
            Destroy(bouton);
        }
        boutonsActifs.Clear();
    }

    public void PageSuivante()
    {
        if((numeroPage + 1) * maxItemsParPages < listeItems.itemsAVendre.Count)
        {
            numeroPage++;
            AfficherItems();
        }
    }

    public void PagePrecedente()
    {
        if(numeroPage > 0)
        {
            numeroPage--;
            AfficherItems();
        }
    }

    public void Acheter(ItemDataMagasin item, GameObject bouton)
    {
        if (inventaire.debris >= item.prix)
        {
            switch (item.type)
            {
                case ItemType.Radiation:
                    statsJoueur.maxRadiation += item.bonus;
                    break;
                case ItemType.SeringueEfficacite:
                    statsJoueur.efficaciteSeringue += item.bonus;
                    break;
                case ItemType.SeringueMax:
                    inventaire.maxSeringue += item.bonus;
                    break;
                case ItemType.Degats:
                    statsJoueur.degats += item.bonus;
                    break;
            }
            
            inventaire.debris -= item.prix;
            Destroy(bouton);
            
            listeItems.itemsAVendre.Remove(item);
            inventaire.items.Add(item);
            
            AfficherItems();
        }
    }
}
