using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SerializableVector3
{
    public float x, y, z;

    public SerializableVector3(float rX, float rY, float rZ)
    {
        x = rX;
        y = rY;
        z = rZ;
    }

    public static implicit operator Vector3(SerializableVector3 sv) => new Vector3(sv.x, sv.y, sv.z);
    public static implicit operator SerializableVector3(Vector3 v) => new SerializableVector3(v.x, v.y, v.z);
}

[System.Serializable]
public class EtatJeu
{
    public string NomSauvegarde;
    public SerializableVector3 PositionJoueur;
    // public List<Item> ItemsInventaire;
    // public List<Item> ItemsMagasin;

    public EtatJeu(string nomSauvegarde, Vector3 positionJoueur)
    {
        NomSauvegarde = nomSauvegarde;
        PositionJoueur = positionJoueur;
        // ItemsInventaire = new List<Item>();
        // ItemsMagasin = new List<Item>();
    }
}
