using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements.Experimental;

public class MenuUI : MonoBehaviour
{
    private bool pause = false;

    public GameObject menuPause;

    public Button continuer;
    public Button parametres;
    public Button sauvegarder;
    public Button charger;
    public Button quitter;

    public bool menuParametresVisible;

    public GameObject menuParametres;

    public Slider volume;

    public Slider luminosite;
    public Light lumierePrincipale;

    public Button appliquer;

    void Start()
    {
        menuParametresVisible = false;

        float volumeSauvegarder = PlayerPrefs.GetFloat("Volume", 1.0f);

        volume.value = volumeSauvegarder;
        volume.onValueChanged.AddListener(ChangerVolume);

        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 2.0f);
        luminosite.value = savedBrightness;
        
        luminosite.onValueChanged.AddListener(ChangerLuminosite);
        
        ChangerLuminosite(savedBrightness);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }

        continuer.onClick.AddListener(Continuer);
        parametres.onClick.AddListener(Parametres);
        sauvegarder.onClick.AddListener(Sauvegarder);
        charger.onClick.AddListener(Charger);
        quitter.onClick.AddListener(Quitter);

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

    void Sauvegarder()
    {
        // Système de sauvegarde
    }

    void Charger()
    {
        // Système de sauvegarde
    }

    void Quitter()
    {
        Application.Quit();
    }

    // Paramètres
    void ChangerVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    void ChangerLuminosite(float luminosite)
    {
        lumierePrincipale.intensity = luminosite;

        PlayerPrefs.SetFloat("Brightness", luminosite);
        PlayerPrefs.Save();
    }

    void Appliquer()
    {
        menuParametresVisible = false;
        menuPause.SetActive(true);
    }
}

