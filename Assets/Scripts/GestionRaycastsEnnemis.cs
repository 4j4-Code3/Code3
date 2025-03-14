using UnityEngine;

public class GestionRaycastsEnnemis : MonoBehaviour
{
    public Transform joueur;

    public float rayonSphere;
    public bool joueurVu = false;

    void Update()
    {
        DetecterJoueur();
    }

    void DetecterJoueur()
    {
        Vector3 direction = joueur.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit hit;

        if (Physics.SphereCast(transform.position, rayonSphere, direction, out hit, distance, LayerMask.GetMask("Default")))
        {
            return;
        }
        else if (Physics.SphereCast(transform.position, rayonSphere, direction, out hit, distance, LayerMask.GetMask("Joueur")))
        {
            joueurVu = true;
        }

    }
}
