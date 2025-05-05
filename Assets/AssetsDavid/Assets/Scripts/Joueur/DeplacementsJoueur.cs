using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsJoueur : MonoBehaviour
{
    public StatsJoueur statsJoueur;
    public bool mort;

    private CharacterController characterController;
    private float touchesVerticals;
    private float touchesHorizontals;
    public float vitesse = 10f;
    private Vector3 velocite;
    public Transform dataTransform;



    public float vitesseSouris = 700f;
    public float rotationX = 0f;

    public InventaireUI inventaireUI;
    public MagasinUI magasinUI;

    private Animator animator;

   

    // Gère les déplacements du joueur
    void Start()
    {
        mort = false;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {

        touchesVerticals = Input.GetAxis("Vertical");
        touchesHorizontals = Input.GetAxis("Horizontal");

        AnimationDeplacement();

        if (!mort)
        {
            Deplacements();
        }

        if (statsJoueur.radiation >= statsJoueur.maxRadiation)
        {
            mort = true;
        }
        else
        {
            mort = false;
        }

        if (inventaireUI.inventaireUIActif || magasinUI.magasinUIActif)
        {
            return;
        }
        else
        {
            TournerX();
        }

        dataTransform.position = gameObject.transform.position;
        dataTransform.rotation = gameObject.transform.rotation;
    }

    void Deplacements()
    {
        Vector3 mouvements = (transform.forward * touchesVerticals + transform.right * touchesHorizontals) * vitesse;

        if (characterController.isGrounded)
        {
            if (velocite.y < 0)
            {
                velocite.y = -2f;
            }
        }
        else
        {
            velocite.y += Physics.gravity.y * Time.deltaTime;
        }

        mouvements.y = velocite.y;

        characterController.Move(mouvements * Time.deltaTime);
        
    }

    void TournerX()
    {
        float deplacementSourisX = Input.GetAxis("Mouse X") * vitesseSouris * Time.deltaTime;
        rotationX += deplacementSourisX;
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
    }

    void AnimationDeplacement()
    {
        if (characterController.velocity.magnitude > 0.1f)
        {
            animator.SetBool("marche", true);
        }
        else
        {
            animator.SetBool("marche", false);
        }
    }
}
