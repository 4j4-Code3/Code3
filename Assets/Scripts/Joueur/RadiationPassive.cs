using UnityEngine;

public class RadiationPassive : MonoBehaviour
{
    public Inventaire inventaire;

    public StatsJoueur statsJoueur;

    void Start()
    {
        inventaire.seringueSpeciale = false;
        InvokeRepeating("Radiation", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(inventaire.seringueSpeciale)
        {
            CancelInvoke("Radiation");
        }
    }

    void Radiation()
    {
        statsJoueur.radiation += 1f;
    }
}
