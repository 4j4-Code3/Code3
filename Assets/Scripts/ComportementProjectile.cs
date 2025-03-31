using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementProjectile : MonoBehaviour
{
// À mettre sur un projectile

// Gère la destruction des projectiles

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
