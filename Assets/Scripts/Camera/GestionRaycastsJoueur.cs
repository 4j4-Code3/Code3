using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GestionRaycastsJoueur : MonoBehaviour
{
    private int distanceRaycasts = 2;

    public TextMeshProUGUI texteInteraction;

    public GameObject magasinUI;

    public MagasinUI magasinUIActif;

    public Inventaire inventaire;

    public GameObject mainDroite;

    public GestionPorteFinale gestionPorteFinale;

    public List<GameObject> lumieres;

    public UnityEngine.UI.Image image;
    private float duree = 3f;

    public bool estArme;

    public bool generateur;
    public bool fonctionne;

    private bool regardeRigidbody;



    public AudioSource SourceAudio;
    public AudioClip SonClefClip;
    public AudioClip SonLumieres;
    public AudioClip SonAscenceur;
    public AudioClip SonPorteFinale;
    public AudioClip SonPapier;

    private bool sonClefJoue = false;
    private bool sonPorteFinalJoue = false;
    private bool sonLumiereJoue = false;
    private bool sonAscenseurJoue = false;
    private bool sonAscenseur2Joue = false;
    private bool sonPapierJouer = false;

    // Start is called before the first frame update
    void Start()
    {
        estArme = false;
        regardeRigidbody = false;
        generateur = false;
        fonctionne = false;
        magasinUI.SetActive(false);
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

        if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts + 28, LayerMask.GetMask("Default")))
        {
            texteInteraction.text = "";
        }



        // Prendre objets
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts, LayerMask.GetMask("ObjetRigidbody")))
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
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts + 4, LayerMask.GetMask("Arme")))
        {
            texteInteraction.text = "E";

            if (Input.GetKeyDown(KeyCode.E) && !estArme)
            {
                GameObject arme = infoCollision.collider.gameObject;
                Collider armeCollider = arme.GetComponent<Collider>();
                Rigidbody armeRB = arme.GetComponent<Rigidbody>();

                arme.transform.SetParent(mainDroite.transform);
                arme.transform.localPosition = new Vector3(0.24f, 0.07f, 0.21f);
                arme.transform.localRotation = Quaternion.Euler(90, 0, 0);

                armeCollider.enabled = false;
                armeRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                estArme = true;
            }
        }

        // Prendre clef
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts + 5, LayerMask.GetMask("Clef")))
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
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts + 5, LayerMask.GetMask("Note")))
        {
            texteInteraction.text = "E";

            GameObject note = infoCollision.collider.gameObject;

            Note noteComponent = infoCollision.collider.gameObject.GetComponent<Note>();

            if (Input.GetKeyDown(KeyCode.E) && noteComponent != null)
            {
                inventaire.AjouterNote(noteComponent.noteData, noteComponent.gameObject);
                inventaire.items.Add(noteComponent.noteData);
                inventaire.noteMap[noteComponent.noteData] = noteComponent.gameObject;
                Destroy(note);

                //ajout du son pour 2 sec.
                StartCoroutine(JouerSonPapierPendant2Secondes());
            }
        }

        // Prendre item
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts, LayerMask.GetMask("Item")))
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
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts, LayerMask.GetMask("Debris")))
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
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts + 4, LayerMask.GetMask("Seringue")))
        {
            GameObject seringue = infoCollision.collider.gameObject;

            if (inventaire.seringue < inventaire.maxSeringue)
            {
                texteInteraction.text = "E";
                if (Input.GetKeyDown(KeyCode.E))
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
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts, LayerMask.GetMask("SeringueSpeciale")))
        {
            GameObject seringue = infoCollision.collider.gameObject;

            Item itemComponent = infoCollision.collider.gameObject.GetComponent<Item>();

            texteInteraction.text = "E";
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventaire.items.Add(itemComponent.itemData);
                inventaire.seringueSpeciale = true;
                Destroy(seringue);
            }

        }

        // Actionner porte bloquée
        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, distanceRaycasts, LayerMask.GetMask("LecteurPorte")))
        {
            texteInteraction.text = "E";

            LecteurPorte lecteurPorteComponent = infoCollision.collider.gameObject.GetComponent<LecteurPorte>();

            LecteurPorteData lecteurPorte = lecteurPorteComponent.data;

            bool active = false;

            if (lecteurPorte.code != "")
            {
                foreach (var item in inventaire.items)
                {
                    if (item is ClefData clef && clef.code == lecteurPorte.code)
                    {
                        active = true;
                    }
                }

                if (Input.GetKeyDown(KeyCode.E) && active)
                {
                    Debug.Log("Porte " + lecteurPorte.code + " ouverte");
                    lecteurPorteComponent.porteOuverte = true;
                    
                    // SON CLEF
                    if (!sonClefJoue)
                    {
                        SourceAudio.PlayOneShot(SonClefClip);
                        sonClefJoue = true;
                    } 
                }
            }
            else
            {
                active = true;

                if (Input.GetKeyDown(KeyCode.E) && active)
                {
                    Debug.Log("Porte ouverte");
                    lecteurPorteComponent.porteOuverte = true;
                }
            }
        }

        // Actionner générateur
        if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts, LayerMask.GetMask("Generateur")))
        {
            texteInteraction.text = "E";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (lumieres.Count > 0)
                {
                    foreach (var lumiere in lumieres)
                    {
                        lumiere.GetComponent<Light>().enabled = true;
                    }
                    generateur = true;
                       
                    //Son lumieres
                    if (!sonLumiereJoue)
                    {
                        SourceAudio.PlayOneShot(SonLumieres);
                        sonClefJoue = true;
                    }
                }
            }
        }

        // Actionner ascenseur
        if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts, LayerMask.GetMask("Ascenseur")))
        {
            if (inventaire.items.Exists(item => item.nom == "Bouton"))
            {
                fonctionne = true;
            }

            if (!fonctionne || !generateur)
            {
                texteInteraction.text = "Il manque quelque chose...";
            }

            else if (fonctionne && generateur)
            {
                texteInteraction.text = "E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventaire.items.RemoveAll(item => item.nom == "Bouton");
                    StartCoroutine(CommencerFondu());
                    Debug.Log("L'ascenseur fonctionne");

                    //son ascenceur
                    if (!sonAscenseurJoue)
                    {
                        SourceAudio.PlayOneShot(SonAscenceur);
                        sonClefJoue = true;
                    }
                }
            }
        }

        // Actionner ascenseur Étage 2
        if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts, LayerMask.GetMask("Ascenseur2")))
        {
            texteInteraction.text = "E";
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(CommencerFondu());

                //son ascenceur
                if (!sonAscenseur2Joue)
                {
                    SourceAudio.PlayOneShot(SonAscenceur);
                    sonClefJoue = true;
                }
            }
        }

        // Affichage du UI du magasin
            if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts, LayerMask.GetMask("Marchand")))
            {
                texteInteraction.text = "E";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    magasinUI.SetActive(true);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    magasinUIActif.magasinUIActif = true;
                }
            }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            magasinUI.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            magasinUIActif.magasinUIActif = false;
        }

        // Interaction Porte Finale
        if (Physics.Raycast(camRay.origin, camRay.direction, distanceRaycasts, LayerMask.GetMask("ControleFinal")))
        {
            texteInteraction.text = "E";

            if (Input.GetKeyDown(KeyCode.E) && !gestionPorteFinale.interagis)
            {
                gestionPorteFinale.InteractionConsole();
                texteInteraction.text = "";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                 // SON PORTE FINALE
                if (!sonPorteFinalJoue)
                {
                    SourceAudio.PlayOneShot(SonPorteFinale);
                    sonPorteFinalJoue = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q) && gestionPorteFinale.interagis)
            {
                gestionPorteFinale.InteractionConsole();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        Debug.DrawRay(camRay.origin, camRay.direction * distanceRaycasts, Color.yellow);
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
    
    public void FonduAuNoir()
    {
        StartCoroutine(Fondu(0f, 1f));
    }

    public void FonduInverse()
    {
        StartCoroutine(Fondu(1f, 0f));
    }

    IEnumerator CommencerFondu()
    {
        FonduAuNoir();
        yield return new WaitForSeconds(4);
        StopCoroutine(CommencerFondu());
        SceneManager.LoadScene("Code3E2");
    }

    IEnumerator CommencerFonduInverse()
    {
        FonduInverse();
        yield return new WaitForSeconds(4);
        StopCoroutine(CommencerFonduInverse());
    }

    IEnumerator Fondu(float alphaDebut, float alphaFin)
    {
        float temps = 0f;
        Color couleur = image.color;
        while (temps < duree)
        {
            float alpha = Mathf.Lerp(alphaDebut, alphaFin, temps / duree);
            image.color = new Color(couleur.r, couleur.g, couleur.b, alpha);
            temps += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(couleur.r, couleur.g, couleur.b, alphaFin);
    }

    IEnumerator JouerSonPapierPendant2Secondes()
    {
        SourceAudio.clip = SonPapier;
        SourceAudio.Play();
        yield return new WaitForSeconds(2f);
        SourceAudio.Stop();
    }

}
