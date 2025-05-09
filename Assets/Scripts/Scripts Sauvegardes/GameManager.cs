using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EtatJeu EtatActuel;

    void Start()
    {
        if (GestionSauvegarde.TryRead(out EtatJeu state))
        {
            EtatActuel = state;
        }
        else
        {
            // Système de saisie de nom
            EtatActuel = new EtatJeu(EtatActuel.NomSauvegarde);
            GestionSauvegarde.Write(EtatActuel);
        }
    }
}
