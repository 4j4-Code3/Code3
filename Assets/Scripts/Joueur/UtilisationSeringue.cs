using System.Collections;
using UnityEngine;
using TMPro;

public class UtilisationSeringue : MonoBehaviour
{
    public Inventaire inventaire;
    public StatsJoueur statsJoueur;
    public TextMeshProUGUI nombreSeringues;
    private Animator animator;

    void Start()
    {
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && inventaire.seringue > 0 && statsJoueur.radiation > 0)
        {
            StartCoroutine(UtiliserSeringue());
        }

        nombreSeringues.text = inventaire.seringue.ToString() + " / " + inventaire.maxSeringue.ToString() + " seringues";
    }

    IEnumerator UtiliserSeringue()
    {
        yield return null;
        inventaire.seringue--;
        statsJoueur.radiation -= 5 + statsJoueur.efficaciteSeringue;
        StopCoroutine(UtiliserSeringue());
    }
}
