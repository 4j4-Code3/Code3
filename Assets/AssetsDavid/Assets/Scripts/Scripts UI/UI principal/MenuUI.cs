using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UIElements.Experimental;

public class MenuUI : MonoBehaviour
{
    private bool pause = false;

    public GameObject menuPause;

    public Button continuer;
    public Button parametres;

    public bool menuParametresVisible;

    public GameObject menuParametres;

    public Slider volume;

    public Slider luminosite;
    public Light lumierePrincipale;

    public Slider sensibiliteX;
    public DeplacementsJoueur deplacementsJoueur;

    public Slider sensibiliteY;
    public GestionCamera gestionCamera;
    

    public Button appliquer;

    void Start()
    {
        menuParametresVisible = false;

        float volumeSauvegarde = PlayerPrefs.GetFloat("Volume", 1.0f);

        volume.value = volumeSauvegarde;
        volume.onValueChanged.AddListener(ChangerVolume);

        float luminositeSauvegarde = PlayerPrefs.GetFloat("Luminosite", 2.0f);
        luminosite.value = luminositeSauvegarde;
        
        luminosite.onValueChanged.AddListener(ChangerLuminosite);
        ChangerLuminosite(luminositeSauvegarde);

        float sensibiliteXSauvegarde = PlayerPrefs.GetFloat("SensibiliteX", deplacementsJoueur.vitesseSouris);
        sensibiliteX.value = sensibiliteXSauvegarde;
        sensibiliteX.onValueChanged.AddListener(ChangerSensibiliteX);

        float sensibiliteYSauvegarde = PlayerPrefs.GetFloat("SensibiliteY", gestionCamera.vitesseSouris);
        sensibiliteY.value = sensibiliteYSauvegarde;
        sensibiliteY.onValueChanged.AddListener(ChangerSensibiliteY);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }

        continuer.onClick.AddListener(Continuer);
        parametres.onClick.AddListener(Parametres);

        menuParametres.SetActive(menuParametresVisible);
        appliquer.onClick.AddListener(Appliquer);
        
    }

    void Pause()
    {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        menuPause.SetActive(pause);

        if(pause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Continuer()
    {
        Pause();
    }

    void Parametres()
    {
        menuParametresVisible = true;
        menuPause.SetActive(false);
    }


    // Paramètres
    void ChangerVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    void ChangerLuminosite(float luminosite)
    {
        lumierePrincipale.intensity = luminosite;

        PlayerPrefs.SetFloat("Luminosite", luminosite);
    }
    void ChangerSensibiliteX(float valeur)
    {
        deplacementsJoueur.vitesseSouris = valeur;
        PlayerPrefs.SetFloat("SensibiliteX", valeur);
    }
    void ChangerSensibiliteY(float valeur)
    {
        gestionCamera.vitesseSouris = valeur;
        PlayerPrefs.SetFloat("SensibiliteY", valeur);
    }

    void Appliquer()
    {
        PlayerPrefs.Save();
        menuParametresVisible = false;
        menuPause.SetActive(true);
    }
}

