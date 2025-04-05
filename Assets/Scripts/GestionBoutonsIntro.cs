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
    public Button boutonQuitter;

    public GameObject menuPause;

	//     void Start (){
	// 	boutonControles = boutonControles.GetComponent<Button>();
	// 	boutonControles.onClick.AddListener(JouerSonPapier);
    //     }
        public void Update(){
            if (Input.GetKey(KeyCode.P))
            {
                menuPause.SetActive(true);
                // Time.timeScale = 0;
            }
        }

        public void ChargerSceneCode3()
        {
            SceneManager.LoadScene("Code3E1");
        }

        public void Quitter(){
            Application.Quit();

            Debug.Log ("Tu as quitté le jeu");
        } 

}
