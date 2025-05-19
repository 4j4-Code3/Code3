using UnityEngine;

public class GestionSpawnEtage2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        GameObject joueur = GameObject.Find("Numero3");
        GameObject spawn = GameObject.Find("SpawnEtage2");
        joueur.transform.position = spawn.transform.position;
    }
}
