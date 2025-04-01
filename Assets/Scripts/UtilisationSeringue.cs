using System.Collections;
using UnityEngine;

public class UtilisationSeringue : MonoBehaviour
{
    public Inventaire inventaire;
    public StatsJoueur statsJoueur;
    private Animator animator;

    void Start()
    {
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && inventaire.seringue > 0)
        {
            StartCoroutine(AnimationSeringue());
        }
    }

    IEnumerator AnimationSeringue()
    {
        // Mettre une animation
        yield return new WaitForSeconds(3f);
        inventaire.seringue--;
        statsJoueur.radiation -= 5 - statsJoueur.efficaciteSeringue;
        StopCoroutine(AnimationSeringue());
    }
}
