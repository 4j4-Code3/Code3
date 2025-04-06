using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArmeDistance : MonoBehaviour
{
    public Transform offset;
    public GameObject projectile;

    public GestionRaycastsJoueur armeTenue;

// Gère les armes à distance
    void Start()
    {
        armeTenue = armeTenue.GetComponent<GestionRaycastsJoueur>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && armeTenue.estArme)
        {
            GameObject cloneProjectile = Instantiate(projectile, offset.transform.position, offset.transform.rotation);
            
            Rigidbody rb = cloneProjectile.GetComponent<Rigidbody>();
            rb.AddForce(cloneProjectile.transform.forward * 100f, ForceMode.Impulse);
        }
    }
}
