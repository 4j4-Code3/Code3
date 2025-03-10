using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArmeDistance : MonoBehaviour
{
    public Transform offset;
    public GameObject projectile;

    public GestionRaycastsJoueur armeTenue;

    // Start is called before the first frame update
    void Start()
    {
        armeTenue = armeTenue.GetComponent<GestionRaycastsJoueur>();
    }

    // Update is called once per frame
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
