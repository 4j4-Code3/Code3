using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionBoutonsIntro : MonoBehaviour
{
    // Définir les boutons du menu principal
    public Button boutonNouvellePartie;
    public Button boutonContinuer;
    public Button boutonParametres;
    public Button boutonControles;
    public Button boutonQuitter;

    public AudioClip sonPapier;
    public AudioSource sonClick;
    
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        // Ajouter des listeners aux boutons
        // boutonNouvellePartie.onClick.AddListener(ChargerSceneCode3);
        boutonControles.onClick.AddListener(JouerSonPapier);
        boutonQuitter.onClick.AddListener(Quitter);
    }

    void Update()
    {
        // Vérifier le click du joueur
        if (Input.GetMouseButtonDown(0))
        {
            sonClick.Play();
        }
    }

    // // Charger la scène Code3
    // public void ChargerSceneCode3()
    // {
    //     SceneManager.LoadScene("Code3-e1");
    // }

    // Jouer le son du papier
    public void JouerSonPapier()
    {
        audioSource.PlayOneShot(sonPapier);
        Debug.Log("Son joué");
    }

    // Pour quitter le jeu
    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Tu as quitté le jeu");
    }

}
