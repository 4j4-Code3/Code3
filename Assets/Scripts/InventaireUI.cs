using UnityEngine;

public class InventaireUI : MonoBehaviour
{
    public Inventaire inventaire;

    public GameObject iconePrefab;
    public GameObject parentIcone;


    public bool inventaireUIActif = false;

    void Awake()
    {
        foreach (Item item in inventaire.items)
        {

        }
    }
}
