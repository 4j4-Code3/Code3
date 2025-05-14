using UnityEngine;

public class AnimationPorte : MonoBehaviour
{
    private LecteurPorte lecteurPorteComponent;
    public Animator animator;

// Gère l'animation de la porte
    void Start()
    {
        lecteurPorteComponent = GetComponent<LecteurPorte>();
    }

    void Update()
    {
        animator.SetBool("ouvert", lecteurPorteComponent.porteOuverte);
    }
}
