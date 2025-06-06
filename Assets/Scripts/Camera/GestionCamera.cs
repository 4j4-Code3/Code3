using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestionCamera : MonoBehaviour
{
    public float vitesseSouris = 100f;
    
    public float angleMaxY = 80f;
    public float angleMinY = -35f;

    public float rotationY = 0f;

    public InventaireUI inventaireUI;
    public MagasinUI magasinUI;

    // Gère la rotation y de la caméra
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        magasinUI = GameObject.Find("MagasinUI")?.GetComponent<MagasinUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (inventaireUI.inventaireUIActif || magasinUI.magasinUIActif)
        // {
        //     return;
        // }
        // else
        // {
        //     TournerY();
        // }
        
        TournerY();
    }

// Gère la rotation de la caméra verticale
    void TournerY()
    {
        float deplacementSourisY = Input.GetAxis("Mouse Y") * vitesseSouris * Time.deltaTime;

        rotationY += deplacementSourisY;

        rotationY = Mathf.Clamp(rotationY, angleMinY, angleMaxY);

        transform.localRotation = Quaternion.Euler(-rotationY, 0f, 0f);

    }
}
