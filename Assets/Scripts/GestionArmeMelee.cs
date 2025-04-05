using System.Collections;
using UnityEngine;

public class GestionArmeMelee : MonoBehaviour
{
    public GestionRaycastsJoueur armeTenue;
    public Collider zoneAttaque;
    public ArmeData armeData;
    public StatsJoueur statsJoueur;
    public GameObject mainDroite;
    private Animator animator;

    void Start()
    {
        armeTenue = armeTenue.GetComponent<GestionRaycastsJoueur>();
        animator = GetComponent<Animator>();
        zoneAttaque.enabled = false;
    }

// Gère les armes de mêlées
    void Update()
    {
        if (mainDroite.transform.childCount == 6)
        {
            Transform infoEnfant = mainDroite.transform.GetChild(mainDroite.transform.childCount - 1);
            GameObject enfant = infoEnfant.gameObject;
            
            Arme armeComponent = enfant.GetComponent<Arme>();

            armeData = armeComponent.armeData;
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            armeData = null;
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && armeTenue.estArme)
        {
            StartCoroutine(ReceptionDegats());
            AnimationAttaque();
        }
    }

    IEnumerator ReceptionDegats()
    {
        zoneAttaque.enabled = true;
        yield return new WaitForSeconds(1);
        zoneAttaque.enabled = false;
        StopCoroutine(ReceptionDegats());
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ennemi"))
        {
            ComportementEnnemis ennemi = collider.gameObject.GetComponent<ComportementEnnemis>();
            ennemi.vie -= armeData.degats - statsJoueur.degats;
        }
    }

    void AnimationAttaque()
    {
        animator.SetTrigger("attaque");
    }
}
