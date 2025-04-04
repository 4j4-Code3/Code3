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
    public AudioClip sonClick;
    
    public AudioSource audioSource; 

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        // Ajouter des listeners aux boutons
        // boutonNouvellePartie.onClick.AddListener(ChargerSceneCode3);
        boutonQuitter.onClick.AddListener(Quitter);
    }

    // void Update()
    // {
    //     // Vérifier le click du joueur
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         audioSource.PlayOneShot(sonClick);
    //     }
    // }

    // // Charger la scène Code3
    // public void ChargerSceneCode3()
    // {
    //     SceneManager.LoadScene("Code3-e1");
    // }

    // Pour quitter le jeu
    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Tu as quitté le jeu");
    }

}
