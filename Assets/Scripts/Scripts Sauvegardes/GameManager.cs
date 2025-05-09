using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public EtatJeu EtatActuel;
    public Transform transformJoueur;
    public List<Item> inventaireActuel; 
    public List<Item> magasinActuel;

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
        // EtatActuel.ItemsInventaire = new List<Item>(inventaireActuel);
        // EtatActuel.ItemsMagasin = new List<Item>(magasinActuel);
    }

    private void ApplyEtatToGame()
    {
        transformJoueur.position = EtatActuel.PositionJoueur;
        // inventaireActuel = new List<Item>(EtatActuel.ItemsInventaire);
        // magasinActuel = new List<Item>(EtatActuel.ItemsMagasin);
    }
}

