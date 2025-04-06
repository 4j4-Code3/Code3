using UnityEngine;

[System.Serializable]
public class DataJeu
{
    public int nombreMorts;
    public Vector3 positionJoueur;

// Valeurs initiales quand on commence une partie
    public DataJeu()
    {
        this.nombreMorts = 0;
    }
}
