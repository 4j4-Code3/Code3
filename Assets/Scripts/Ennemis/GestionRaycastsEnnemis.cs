using UnityEngine;

public class GestionRaycastsEnnemis : MonoBehaviour
{
    public Transform transformJoueur;
    public GameObject joueur;

    public float rayonSphere;
    public bool joueurVu = false;

    // Gère la détection du joueur
    void Start()
    {
        joueur = GameObject.Find("Numero3");
        transformJoueur = joueur.transform;
    }
    void Update()
    {
        DetecterJoueur();
    }

    void DetecterJoueur()
    {
        Vector3 direction = transformJoueur.position - transform.position;
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
