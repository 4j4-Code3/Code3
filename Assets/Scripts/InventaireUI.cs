using UnityEngine;
using UnityEngine.UI;

public class InventaireUI : MonoBehaviour
{
    public Inventaire inventaire;
    public GameObject inventaireUI;

    public GameObject iconePrefab;
    public GameObject parentIcone;


    public bool inventaireUIActif = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !inventaireUIActif)
        {
            foreach (Item item in inventaire.items)
            {
                GameObject cloneIcone = Instantiate(iconePrefab, parentIcone.transform);
                cloneIcone.GetComponent<Image>().sprite = item.icone;
            }
            inventaireUIActif = true;
            inventaireUI.SetActive(inventaireUIActif);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventaireUIActif)
        {
            foreach (Transform enfant in parentIcone.transform)
            {
                Destroy(enfant.gameObject);
            }
            inventaireUIActif = false;
            inventaireUI.SetActive(inventaireUIActif);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
