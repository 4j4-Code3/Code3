using UnityEngine;

public class AnimationPorte : MonoBehaviour
{
    private LecteurPorte lecteurPorteComponent;
    private Animator animator;

// Gère l'animation de la porte
    void Start()
    {
        lecteurPorteComponent = GetComponent<LecteurPorte>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        // animator.SetBool("ouvert", lecteurPorteComponent.porteOuverte);
    }
}
