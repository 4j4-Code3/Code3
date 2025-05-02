using UnityEngine;
using TMPro;

public class AffichageDebris : MonoBehaviour
{
    public TextMeshProUGUI nombreDebris;
    public Inventaire inventaire;

    // Update is called once per frame
    void Update()
    {
        nombreDebris.text = inventaire.debris.ToString() + " débris";
    }
}
