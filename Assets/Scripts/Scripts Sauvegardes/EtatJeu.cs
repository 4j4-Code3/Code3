using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EtatJeu
{
    public string NomSauvegarde;
    public Vector3 PlayerPosition;
    public List<Item> ItemsInventaire;
    public List<Item> ItemsMagasin;

    public EtatJeu(string nomSauvegarde)
    {
        NomSauvegarde = nomSauvegarde;
        PlayerPosition = Vector3.zero;
        ItemsInventaire = new List<Item>();
        ItemsMagasin = new List<Item>();
    }
}
