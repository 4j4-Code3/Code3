using UnityEngine;
using TMPro;
using static UnityEditor.Progress;


public class GestionRaycastsJoueur : MonoBehaviour
{
    public TextMeshProUGUI texteInteraction;

    public GameObject magasinUI;

    public MagasinUI magasinUIActif;

    public Inventaire inventaire;

    public GameObject mainDroite;

    // public GestionPorteFinale gestionPorteFinale;

    public bool estArme;
    private bool generateur;

    private bool regardeRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        estArme = false;
        regardeRigidbody = false;
        generateur = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastsInteractions();
        LacherArme();
    }

// !!! Ajouter les layers aux GameObjects !!! 
    void RaycastsInteractions()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit infoCollision;

        if (Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("Default")))
        {
            texteInteraction.text = "";
        }

        // Prendre objets
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("ObjetRigidbody")))
        {
            texteInteraction.text = "E";

            Rigidbody rb = infoCollision.collider.GetComponent<Rigidbody>();

            if (Input.GetKey(KeyCode.E))
            {
                if (!regardeRigidbody)
                {
                    regardeRigidbody = true;
                    infoCollision.collider.gameObject.transform.LookAt(camRay.origin);
                }
                
                Vector3 position = Camera.main.transform.position + Camera.main.transform.forward * 3f;
                rb.MovePosition(position);

                rb.useGravity = false;
            }
            else
            {
                regardeRigidbody = false;

                rb.useGravity = true;
            }
        }

        // Prendre arme
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Arme")))
        {
            texteInteraction.text = "E";

            if(Input.GetKeyDown(KeyCode.E) && !estArme)
            {
                GameObject arme = infoCollision.collider.gameObject;
                Collider armeCollider = arme.GetComponent<Collider>();
                Rigidbody armeRB = arme.GetComponent<Rigidbody>();
                
                arme.transform.SetParent(mainDroite.transform);
                arme.transform.localPosition = new Vector3(0, 0, 0);
                arme.transform.localRotation = Quaternion.identity;

                armeCollider.enabled = false;
                armeRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                estArme = true;
            }
        }

        // Prendre clef
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Clef")))
        {
            texteInteraction.text = "E";

            GameObject clef = infoCollision.collider.gameObject;

            Clef clefComponent = infoCollision.collider.gameObject.GetComponent<Clef>();

            if (Input.GetKeyDown(KeyCode.E) && clefComponent != null)
            {
                inventaire.items.Add(clefComponent.clefData);
                Destroy(clef);
            }
        }

        // Prendre note
        if(Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Note")))
        {
            texteInteraction.text = "E";

            GameObject note = infoCollision.collider.gameObject;

            // Note noteComponent = infoCollision.collider.gameObject.GetComponent<Note>();

            // if (Input.GetKeyDown(KeyCode.E) && noteComponent != null)
            // {
            //     inventaire.AjouterNote(noteComponent.noteData, noteComponent.gameObject);
            //     inventaire.items.Add(noteComponent.noteData);
            //     inventaire.noteMap[noteComponent.noteData] = noteComponent.gameObject;
            //     Destroy(note);
            // }
        }

        // Prendre item
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Item")))
        {
            texteInteraction.text = "E";

            GameObject item = infoCollision.collider.gameObject;

            Item itemComponent = infoCollision.collider.gameObject.GetComponent<Item>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                inventaire.items.Add(itemComponent.itemData);
                Destroy(item);
            }
        }

        // Prendre debris
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Debris")))
        {
            texteInteraction.text = "E";

            GameObject debris = infoCollision.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                inventaire.debris++;
                Destroy(debris);
            }
        }

        // Prendre seringue
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("Seringue")))
        {
            GameObject seringue = infoCollision.collider.gameObject;

            if (inventaire.seringue < inventaire.maxSeringue)
            {
                texteInteraction.text = "E";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    inventaire.seringue++;
                    Destroy(seringue);
                }
            }
            else
            {
                texteInteraction.text = "Plus de place!";
            }
        }

        // Prendre seringue spéciale
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("SeringueSpeciale")))
        {
            GameObject seringue = infoCollision.collider.gameObject;

            Item itemComponent = infoCollision.collider.gameObject.GetComponent<Item>();

            texteInteraction.text = "E";
            // if (Input.GetKeyDown(KeyCode.E))
            // {
            //     inventaire.items.Add(itemComponent.itemData);
            //     inventaire.seringueSpeciale = true;
            //     Destroy(seringue);
            // }
           
        }

        // Actionner porte bloquée
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 10, LayerMask.GetMask("LecteurPorte")))
        {
            texteInteraction.text = "E";

            LecteurPorte lecteurPorteComponent = infoCollision.collider.gameObject.GetComponent<LecteurPorte>();

            LecteurPorteData lecteurPorte = lecteurPorteComponent.data;

            bool active = false;

            if(lecteurPorte.code != "")
            {
                foreach (var item in inventaire.items)
                {
                    if (item is ClefData clef && clef.code == lecteurPorte.code)
                    {
                        active = true;
                    }
                }

                if(Input.GetKeyDown(KeyCode.E) && active)
                {
                    Debug.Log("Porte " + lecteurPorte.code + " ouverte");
                    lecteurPorteComponent.porteOuverte = true;
                }
            }
            else
            {
                active = true;

                if(Input.GetKeyDown(KeyCode.E) && active)
                {
                    Debug.Log("Porte ouverte");
                    lecteurPorteComponent.porteOuverte = true;
                }
            }
        }

        // Actionner générateur
        if (Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("Generateur")))
        {
            texteInteraction.text = "E";

            if(Input.GetKeyDown(KeyCode.E))
            {
                /*
                    Quelque chose...
                */
                generateur = true;
            }
        }

        // Actionner ascenseur
        if (Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("Ascenseur")))
        {
            texteInteraction.text = "E";

            bool fonctionne = inventaire.items.Exists(item => item.nom == "Bouton");

            if (Input.GetKeyDown(KeyCode.E) && fonctionne && generateur)
            {
                inventaire.items.RemoveAll(item => item.nom == "Bouton");
                Debug.Log("L'ascenseur fonctionne");
            }
        }

        // Affichage du UI du magasin
        if (Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("Marchand")))
        {
            texteInteraction.text = "E";

            if(Input.GetKeyDown(KeyCode.E))
            {
                magasinUI.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                magasinUIActif.magasinUIActif = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            magasinUI.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            magasinUIActif.magasinUIActif = false;
        }

        // Interaction Porte Finale
        if(Physics.Raycast(camRay.origin, camRay.direction, 10, LayerMask.GetMask("ControleFinal")))
        {
            texteInteraction.text = "E";

            // if(Input.GetKeyDown(KeyCode.E))
            // {
            //     gestionPorteFinale.InteractionConsole();
            // }
        }

        Debug.DrawRay(camRay.origin, camRay.direction * 10, Color.yellow);
    }

    void LacherArme()
    {
        if (Input.GetKeyDown(KeyCode.Q) && estArme)
        {
            Transform infoEnfant = mainDroite.transform.GetChild(mainDroite.transform.childCount - 1);
            GameObject enfant = infoEnfant.gameObject;
            Collider colliderEnfant = enfant.GetComponent<Collider>();
            Rigidbody rigidbodyEnfant = enfant.GetComponent<Rigidbody>();

            enfant.transform.SetParent(null);
            colliderEnfant.enabled = true;
            rigidbodyEnfant.constraints = RigidbodyConstraints.FreezePositionX & RigidbodyConstraints.FreezePositionY & RigidbodyConstraints.FreezePositionZ;

            estArme = false;
        }
    }
}
