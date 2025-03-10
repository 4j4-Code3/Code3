using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class ComportementEnnemis : MonoBehaviour
{
    public float vie;
    public GameObject joueur;
    NavMeshAgent ennemi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ennemi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ennemi.SetDestination(joueur.transform.position);
    }

    IEnumerator AnimationAttaque()
    {
        ennemi.isStopped = true;
        //Déclencher l'animation d'attaque
        yield return new WaitForSeconds(2f);
        ennemi.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AnimationAttaque());
        }
        
    }
}
