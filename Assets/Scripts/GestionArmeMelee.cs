using System.Collections;
using UnityEngine;

public class GestionArmeMelee : MonoBehaviour
{
    public GestionRaycastsJoueur armeTenue;
    public Collider zoneAttaque;
    public ArmeData armeData;

    void Start()
    {
        armeTenue = armeTenue.GetComponent<GestionRaycastsJoueur>();
        zoneAttaque.enabled = false;
    }

    void Update()
    {
        if (Camera.main.transform.childCount != 0)
        {
            Transform infoEnfant = Camera.main.transform.GetChild(0);
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
            ennemi.vie -= armeData.degats;
        }
    }
}
