using UnityEngine;

[System.Serializable]
public class DataJeu
{
    public int nombreMorts;

// Valeurs initiales quand on commence une partie
    public DataJeu()
    {
        this.nombreMorts = 0;
    }
}
