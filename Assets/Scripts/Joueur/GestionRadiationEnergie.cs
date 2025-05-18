using UnityEngine;
using UnityEngine.UI;

public class GestionRadiationEnergie : MonoBehaviour
{
    public StatsJoueur statsJoueur;
    public Slider barreRadiation;

    // Associe la valeur de radiation à la barre de radiation du UI 

    private void Update()
    {
        barreRadiation.value = statsJoueur.radiation;
        if (barreRadiation.value > statsJoueur.maxRadiation)
        {
            barreRadiation.value = statsJoueur.maxRadiation;
        }
    }
}
