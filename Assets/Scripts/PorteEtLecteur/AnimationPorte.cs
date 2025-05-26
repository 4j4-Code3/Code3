using UnityEngine;

public class AnimationPorte : MonoBehaviour
{
    private LecteurPorte lecteurPorteComponent;
    public Animator animator;
    public AudioSource SourceAudio; 
    public AudioClip SonPorteClip;

    private bool SonJouer = false;

    // Gère l'animation de la porte
    void Start()
    {
        lecteurPorteComponent = GetComponent<LecteurPorte>();
    }

    void Update()
    {

        bool porteEstOuverte = lecteurPorteComponent.porteOuverte;

        animator.SetBool("ouvert", porteEstOuverte);

        // Joue quand la porte ouvre
        if (porteEstOuverte && !SonJouer)
        {
            SourceAudio.PlayOneShot(SonPorteClip);
            SonJouer = true;
        }

        // Reset quand la porte ferme)
        if (!porteEstOuverte)
        {
            SonJouer = false;
        }

    }
}
