using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public EtatJeu EtatActuel;
    public Transform transformJoueur;
    public List<ItemData> inventaireActuel; 
    public List<ItemData> magasinActuel;
    public ItemDatabase itemDatabase;

    void Start()
    {
        Debug.Log("Initial inventory: " + inventaireActuel.Count + " items.");
        if (GestionSauvegarde.TryRead(out EtatJeu state))
        {
            EtatActuel = state;
            ApplyEtatToGame();
        }
        else
        {
            string nomParDefaut = "NouvelleSauvegarde";
            EtatActuel = new EtatJeu(nomParDefaut, transformJoueur.position);
            CaptureEtatFromGame();
            GestionSauvegarde.Write(EtatActuel);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
            Debug.Log("Sauvegardé");
        }
    }

    public void SaveGame()
    {
        CaptureEtatFromGame();
        GestionSauvegarde.Write(EtatActuel);
    }

    private void CaptureEtatFromGame()
    {
        EtatActuel.PositionJoueur = transformJoueur.position;
        EtatActuel.ItemsInventaireIDs = new List<string>();
        EtatActuel.ItemsMagasinIDs = new List<string>();

        Debug.Log("Saving Inventory: " + inventaireActuel.Count + " items.");

        foreach (var item in inventaireActuel)
        {
            Debug.Log("Saving item ID: " + item.ID);
            if (!string.IsNullOrEmpty(item.ID))
                EtatActuel.ItemsInventaireIDs.Add(item.ID);
        }

        foreach (var item in inventaireActuel)
        {
            if (!string.IsNullOrEmpty(item.ID))
                EtatActuel.ItemsInventaireIDs.Add(item.ID);
    
        }

        foreach (var item in magasinActuel)
        {
            if (!string.IsNullOrEmpty(item.ID))
                EtatActuel.ItemsMagasinIDs.Add(item.ID);
        }
    }

    private void ApplyEtatToGame()
    {
        transformJoueur.position = EtatActuel.PositionJoueur;

        inventaireActuel = new List<ItemData>();
        magasinActuel = new List<ItemData>();

        foreach (var id in EtatActuel.ItemsInventaireIDs)
        {
            ItemData item = itemDatabase.GetItemByID(id);
            if (item != null) inventaireActuel.Add(item);
        }

        foreach (var id in EtatActuel.ItemsMagasinIDs)
        {
            ItemData item = itemDatabase.GetItemByID(id);
            if (item != null) magasinActuel.Add(item);
        }
    }
}
