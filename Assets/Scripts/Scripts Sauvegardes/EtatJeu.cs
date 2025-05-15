using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[DataContract]
public struct SerializableVector3
{
   [DataMember] public float x, y, z;

    public SerializableVector3(float rX, float rY, float rZ)
    {
        x = rX;
        y = rY;
        z = rZ;
    }

    public static implicit operator Vector3(SerializableVector3 sv) => new Vector3(sv.x, sv.y, sv.z);
    public static implicit operator SerializableVector3(Vector3 v) => new SerializableVector3(v.x, v.y, v.z);
}



[DataContract]
public class EtatJeu
{
    [DataMember] public string NomSauvegarde;
    [DataMember] public SerializableVector3 PositionJoueur;
    [DataMember] public List<string> ItemsInventaireIDs;
    [DataMember] public List<string> ItemsMagasinIDs;

    public EtatJeu(string nomSauvegarde, Vector3 positionJoueur)
    {
        NomSauvegarde = nomSauvegarde;
        PositionJoueur = positionJoueur;
        ItemsInventaireIDs = new List<string>();
        ItemsMagasinIDs = new List<string>();
    }

    public EtatJeu() { }
}

