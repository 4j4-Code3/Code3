using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGestionnaireSauvegardes
{
    void ChargerDonnees(DataJeu donnees);

    void SauvegarderDonnes( ref DataJeu donnees);

}
