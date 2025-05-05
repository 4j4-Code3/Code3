using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameData
{
    public DeplacementsJoueur deplacementsJoueur;
    public StatsJoueur statsJoueur;
    public Inventaire inventaire;
}

public class SauvegardeJSON : MonoBehaviour
{
    GameData gameData;
    string saveFilePath;


    public GameObject joueur;

    public Button sauvegarder;
    public Button charger;
    public Button quitter;

    void Start()
    {
        gameData = new GameData();
        saveFilePath = Application.persistentDataPath + "/GameData.json";
        NewGame();
        sauvegarder.onClick.AddListener(SaveGame);
        charger.onClick.AddListener(LoadGame);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.N))
            NewGame();*/

        ChangeData();
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, savePlayerData);

        Debug.Log("Save file created at: " + saveFilePath);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            gameData = JsonUtility.FromJson<GameData>(loadPlayerData);

            Debug.Log("");
        }
        else
            Debug.Log("There is no save files to load!");

    }

    public void NewGame()
    {
        gameData.statsJoueur.radiation = 0;
        gameData.statsJoueur.maxRadiation = 25;
        gameData.statsJoueur.efficaciteSeringue = 5;
        gameData.statsJoueur.degats = 0;

        gameData.deplacementsJoueur.dataTransform.position = Vector3.zero;

        Debug.Log(gameData.deplacementsJoueur.dataTransform.position = Vector3.zero);
    }

    public void ChangeData()
    {
        joueur.transform.position = gameData.deplacementsJoueur.dataTransform.position;
        gameData.statsJoueur.radiation = gameData.statsJoueur.radiation;

        Debug.Log(joueur.transform.position = gameData.deplacementsJoueur.dataTransform.position);
    }
}