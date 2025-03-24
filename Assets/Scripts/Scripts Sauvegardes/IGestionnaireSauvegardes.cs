using System;
using UnityEngine;

public interface IGestionnaireSauvegardes
{
    void ChargerDonnees(GameObject donnees);

    void SauvegarderDonnes( ref GameObject donnees);

}
