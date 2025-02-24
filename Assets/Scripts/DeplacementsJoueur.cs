using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementsJoueur : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private float touchesVerticals;
    private float touchesHorizontals;
    public float vitesse = 10f;

    public float vitesseSouris = 1000f;
    public float rotationX = 0f;

    public float forceSaut = 10f;
    private bool estAuSol = true;

    // Quand on tombe la gravité est accéléré
    public float multiplicateurGravite = 2f;

    // Quand on saute la gravité est ralentie
    public float diviseurGravite = 0.5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        touchesVerticals = Input.GetAxis("Vertical");
        touchesHorizontals = Input.GetAxis("Horizontal");

        Deplacements();
        TournerX();
    }

    void Deplacements()
    {
        Vector3 mouvements = (transform.forward * touchesVerticals + transform.right * touchesHorizontals) * vitesse;
        rigidbody.linearVelocity = new Vector3(mouvements.x, rigidbody.linearVelocity.y, mouvements.z);

        if (Input.GetKeyDown(KeyCode.Space) && estAuSol)
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, forceSaut, rigidbody.linearVelocity.z);
            estAuSol = false;
        }
        
        if (!estAuSol)
        {
            if (rigidbody.linearVelocity.y > 0)
            {
                rigidbody.linearVelocity += Vector3.up * Physics.gravity.y * diviseurGravite * Time.deltaTime;
            }
            else
            {
                rigidbody.linearVelocity += Vector3.up * Physics.gravity.y * multiplicateurGravite * Time.deltaTime;
            }
        }
    }

    void TournerX()
    {
        float deplacementSourisX = Input.GetAxis("Mouse X") * vitesseSouris * Time.deltaTime;
        rotationX += deplacementSourisX;
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            estAuSol = true;
        }
    }
}

