using UnityEngine;

public class GestionDebrisJoueur : MonoBehaviour
{
    public int debris = 100;

    public bool PeutAcheter(int valeur)
    {
        return debris >= valeur;
    }

    public void AjouterDebris(int valeur)
    {
        debris += valeur;
    }

    public void EnelverDebris(int valeur)
    {
        if (PeutAcheter(valeur))
        {
            debris -= valeur;
        }
    }
}
