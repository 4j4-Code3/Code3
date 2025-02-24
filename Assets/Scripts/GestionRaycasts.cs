using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System.Data;
using Unity.VisualScripting;

public class GestionRaycasts : MonoBehaviour
{
    public TextMeshProUGUI texteInteraction;
    
    public bool estArme;

    // Start is called before the first frame update
    void Start()
    {
        estArme = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastsInteractions();

        if (Input.GetKeyDown(KeyCode.Q) && estArme)
        {
            Transform infoEnfant = Camera.main.transform.GetChild(0);
            GameObject enfant = infoEnfant.gameObject;
            Collider colliderEnfant = enfant.GetComponent<Collider>();
            Rigidbody rigidbodyEnfant = enfant.GetComponent<Rigidbody>();

            enfant.transform.SetParent(null);
            colliderEnfant.enabled = true;
            rigidbodyEnfant.constraints = RigidbodyConstraints.FreezePositionX & RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezePositionZ;

            estArme = false;
        }
    }

    void RaycastsInteractions()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit infoCollision;

        if (Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("Default")))
        {
            texteInteraction.text = "";
        }
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Arme")))
        {
            texteInteraction.text = "E";

            if(Input.GetKeyDown(KeyCode.E) && !estArme)
            {
                GameObject arme = infoCollision.collider.gameObject;
                Collider armeCollider = arme.GetComponent<Collider>();
                Rigidbody armeRB = arme.GetComponent<Rigidbody>();
                
                arme.transform.SetParent(Camera.main.transform);
                arme.transform.localPosition = new Vector3(0.5f, 0, 0.5f);
                arme.transform.localRotation = Quaternion.identity;

                armeCollider.enabled = false;
                armeRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                estArme = true;
            }
        }

        Debug.DrawRay(camRay.origin, camRay.direction * 10, Color.yellow);
    }
}
