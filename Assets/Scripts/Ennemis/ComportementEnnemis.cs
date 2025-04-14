using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemis : MonoBehaviour
{
    private int _vie;
    public event Action<int> changementVie;
    public int Vie
    {
        get => _vie;
        set
        {
            if(_vie != value)
            {
                _vie = value;
                changementVie?.Invoke(_vie);
                // audioSource.PlayOneShot(monstreDegats);
            }
            if (_vie <= 0)
            {
                Mourir();
            }
        }
    }

    private bool actif;

    public GameObject joueur;
    public StatsJoueur statsJoueur;

    NavMeshAgent ennemi;
    GestionRaycastsEnnemis gestionRaycastsEnnemis;

    public Collider collisionDegat;

    private Animator animator;

    public GameObject debrisMonstre;

    // private AudioSource audioSource;
    // public AudioClip monstreDegats;
    // public AudioClip monstreMort;

    

    // Gère le comportement des ennemis en jeu

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gestionRaycastsEnnemis = GetComponent<GestionRaycastsEnnemis>();
        ennemi = GetComponent<NavMeshAgent>();
        // animator = GetComponent<Animator>();
        
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

//  AJOUTER ET AJUSTER L'ANIMATION

    IEnumerator AnimationAttaque()
    {
        ennemi.isStopped = true;
        //D�clencher l'animation d'attaque
        /*
            ICI
        */
        // À enlever quand l'animation est ajouter
        yield return new WaitForSeconds(2f);
        //
        
        ennemi.isStopped = false;
    }
    IEnumerator ReceptionDegat()
    {
        //Activer le collider quand l'animation est censée toucher le joueur
        yield return new WaitForSeconds(3f);
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

    private void Mourir()
    {
        Instantiate(debrisMonstre, transform.position, transform.rotation);
        // audioSource.PlayOneShot(monstreMort);
        Destroy(gameObject);
    }
}
