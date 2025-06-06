using UnityEngine;

public class GestionFeuilles : MonoBehaviour
{
    public GameObject feuilleInfo; // L'image UI à afficher
    public GameObject papierInfos; // L'objet cliquable dans la scène
    public GameObject fermerPapier;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == papierInfos)
                {
                    feuilleInfo.SetActive(true); // Affiche l'image UI
                    fermerPapier.SetActive(true);
                }
            }
        }
    }
}
