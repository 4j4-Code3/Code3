using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventaireUI : MonoBehaviour
{
    public Inventaire inventaire;
    public GameObject inventaireUI;

    public GameObject iconePrefab;
    public GameObject parentIcone;

    private int maxItemsParPages = 9;
    public  int numeroPage = 0;

    public bool inventaireUIActif = false;

// Gère l'affichage de l'inventaire
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !inventaireUIActif)
        {
            numeroPage = 0;

            AfficherItems();

            inventaireUIActif = true;
            inventaireUI.SetActive(inventaireUIActif);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventaireUIActif)
        {
            DetruireItems();

            inventaireUIActif = false;
            inventaireUI.SetActive(inventaireUIActif);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

// Affiche les items dans l'inventaire
    void AfficherItems()
    {
        DetruireItems();

        int debutIndex = numeroPage * maxItemsParPages;
        int finIndex = Mathf.Min(debutIndex + maxItemsParPages, inventaire.items.Count);

        for (int i = debutIndex; i < finIndex; i++)
        {
            ItemData item = inventaire.items[i];

            GameObject cloneIcone = Instantiate(iconePrefab, parentIcone.transform);
            cloneIcone.GetComponent<Image>().sprite = item.icone;

            InfosIcones infos = cloneIcone.GetComponent<InfosIcones>();
            infos.item = item;

            if (item is NoteData noteData && inventaire.noteMap.TryGetValue(noteData, out var noteObject))
            {
                infos.associatedNoteObject = noteObject;
            }
        }
    }

    void DetruireItems()
    {
        foreach (Transform enfant in parentIcone.transform)
            {
                Destroy(enfant.gameObject);
            }
    }

    public void PageSuivante()
    {
        if((numeroPage + 1) * maxItemsParPages < inventaire.items.Count)
        {
            numeroPage++;
            AfficherItems();
        }
    }

    public void PagePrecedente()
    {
        if(numeroPage > 0)
        {
            numeroPage--;
            AfficherItems();
        }
    }

    
}
