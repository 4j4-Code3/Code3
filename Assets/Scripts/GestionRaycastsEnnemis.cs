using UnityEngine;

public class GestionRaycastsEnnemis : MonoBehaviour
{
    public Transform joueur;
    public float porteVision;
    public float rayonSphere;
    public bool joueurVu = false;

    void Update()
    {
        DetecterJoueur();
    }

    void DetecterJoueur()
    {
        Vector3 direction = joueur.position - transform.position;
        // Calcule la distance entre le joueur et l'ennemie et la met dans un float
        float distanceJoueur = direction.magnitude;

        if (distanceJoueur < porteVision)
        {
                RaycastHit hit;

                if (Physics.SphereCast(transform.position, rayonSphere, direction.normalized, out hit, distanceJoueur, LayerMask.GetMask("Joueur")))
                {
                    joueurVu = true;
                }
        }          
    }
}
