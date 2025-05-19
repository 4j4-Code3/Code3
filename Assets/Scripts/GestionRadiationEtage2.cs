using System.Collections;
using UnityEngine;

public class GestionRadiationEtage2 : MonoBehaviour
{
    public Inventaire inventaire;
    public StatsJoueur statsJoueur;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RadiationAmbiante());
    }

    IEnumerator RadiationAmbiante()
    {
        while(!inventaire.seringueSpeciale)
        {
            statsJoueur.radiation++;
            yield return new WaitForSeconds(3);
        }
    }
}
