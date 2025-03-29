using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class GestionnaireSauvegardes : MonoBehaviour
{
    private DataJeu dataJeu;
    public static GestionnaireSauvegardes instance  { get; private set; }
    private List<IGestionnaireSauvegardes> dataPersistenceObjects;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il ne devrait pas y avoir plus d'une instance dans la scène!");
        }
        instance = this;
    }

    public void NouvellePartie()
    {
        this.dataJeu = new DataJeu();
    }

    public void ChargerPartie()
    {
        if(this.dataJeu == null)
        {
            Debug.Log("Aucune donnée trouvée. Les données sont initialisées aux valeurs par défaut.");
            NouvellePartie();
        }

        foreach (IGestionnaireSauvegardes dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.ChargerDonnees(dataJeu);
        }

        Debug.Log("position chargé "+ dataJeu.positionJoueur);
    }

    public void SauvegarderPartie()
    {
        foreach (IGestionnaireSauvegardes dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SauvegarderDonnes(ref dataJeu);
        }

        Debug.Log("position sauvegardé "+ dataJeu.positionJoueur);
    }

    private List<IGestionnaireSauvegardes> FindAllDataPersistenceObjects()
    {
        IEnumerable<IGestionnaireSauvegardes> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IGestionnaireSauvegardes>();
        
        return new List<IGestionnaireSauvegardes>(dataPersistenceObjects);
    }
}
