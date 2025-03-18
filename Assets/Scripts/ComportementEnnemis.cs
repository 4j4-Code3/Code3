using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemis : MonoBehaviour
{
    public float vie;
    private bool actif;

    public GameObject joueur;
    public StatsJoueur statsJoueur;

    NavMeshAgent ennemi;
    GestionRaycastsEnnemis gestionRaycastsEnnemis;

    public Collider collisionDegat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gestionRaycastsEnnemis = GetComponent<GestionRaycastsEnnemis>();
        ennemi = GetComponent<NavMeshAgent>();
        ennemi.isStopped = true;
        actif = false;
    }

    // Update is called once per frame
    void Update()
    {
        ennemi.SetDestination(joueur.transform.position);

        if(gestionRaycastsEnnemis.joueurVu && !actif)
        {
            actif = true;
            ennemi.isStopped = false;
        }
    }

    IEnumerator AnimationAttaque()
    {
        ennemi.isStopped = true;
        //D�clencher l'animation d'attaque
        yield return new WaitForSeconds(2f);
        ennemi.isStopped = false;
    }
    IEnumerator ReceptionDegat()
    {
        //Activer le collider quand l'animation est censée toucher le joueur
        yield return new WaitForSeconds(1f);
        collisionDegat.enabled = true;
        yield return new WaitForSeconds(1f);
        collisionDegat.enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            statsJoueur.radiation += 5;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AnimationAttaque());
            StartCoroutine(ReceptionDegat());
        }
    }
}
