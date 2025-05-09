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

    public void SaveGame()
    {
        CaptureEtatFromGame();
        GestionSauvegarde.Write(EtatActuel);
    }

    private void CaptureEtatFromGame()
    {
        EtatActuel.PositionJoueur = transformJoueur.position;
        EtatActuel.ItemsInventaire = new List<string>();
        EtatActuel.ItemsMagasin = new List<string>();

        foreach (var item in inventaireActuel)
        {
            if (!string.IsNullOrEmpty(item.ID))
                EtatActuel.ItemsInventaire.Add(item.ID);
        }

        foreach (var item in magasinActuel)
        {
            if (!string.IsNullOrEmpty(item.ID))
                EtatActuel.ItemsMagasin.Add(item.ID);
        }
    }

    private void ApplyEtatToGame()
    {
        transformJoueur.position = EtatActuel.PositionJoueur;

        inventaireActuel = new List<ItemData>();
        magasinActuel = new List<ItemData>();

        foreach (var id in EtatActuel.ItemsInventaire)
        {
            ItemData item = itemDatabase.GetItemByID(id);
            if (item != null) inventaireActuel.Add(item);
        }

        foreach (var id in EtatActuel.ItemsMagasin)
        {
            ItemData item = itemDatabase.GetItemByID(id);
            if (item != null) magasinActuel.Add(item);
        }
    }
}
