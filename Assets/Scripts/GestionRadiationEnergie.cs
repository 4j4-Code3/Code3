using UnityEngine;
using UnityEngine.UI;

public class GestionRadiationEnergie : MonoBehaviour
{
    public StatsJoueur statsJoueur;
    public Slider barreRadiation;

    private void Update()
    {
        barreRadiation.value = statsJoueur.radiation;
    }
}
