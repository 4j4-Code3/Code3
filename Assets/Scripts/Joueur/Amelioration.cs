using UnityEngine;
using UnityEngine.UI;

public class Amelioration : MonoBehaviour
{
    public StatsJoueur statsJoueur;
    public Slider barreRadiation;

    // Update is called once per frame
    void Update()
    {
        barreRadiation.maxValue = statsJoueur.maxRadiation;
    }
}
