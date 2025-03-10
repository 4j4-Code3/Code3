using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionBoutonsIntro : MonoBehaviour
{
    public Button boutonNouvellePartie;
    public Button boutonContinuer;
    public Button boutonParametres;
    public Button boutonControles;
    public Button boutonQuitter;

// 	void Start () {
//     // Définir les boutons du menu principal
// 		boutonNouvellePartie = boutonNouvellePartie.GetComponent<Button>();

// 		boutonContinuer = boutonContinuer.GetComponent<Button>();

// 		boutonParametres = boutonParametres.GetComponent<Button>();
// 		boutonParametres.onClick.AddListener(ChargerPageParametres);

// 		boutonControles = boutonControles.GetComponent<Button>();
// 		boutonControles.onClick.AddListener(ChargerPageControles);
//      }

//     public void ChargerSceneCode3()
//     {
//         SceneManager.LoadScene("Code3");
//     }
    
        public void Quitter() {
        Application.Quit();

        Debug.Log ("Tu as quitté le jeu");
        } 

}
