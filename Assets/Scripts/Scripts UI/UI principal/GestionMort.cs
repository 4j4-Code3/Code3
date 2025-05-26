using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GestionMort : MonoBehaviour
{
    public DeplacementsJoueur deplacementsJoueur;
    public StatsJoueur statsJoueur;
    public GameObject joueur;
    public GameObject respawn;
    public Image image;
    private float duree = 3f;

    void Start()
    {
        respawn = GameObject.Find("PointSpawn");
    }

    void Update()
    {
        respawn = GameObject.Find("PointSpawn");
        image = GameObject.Find("FonduNoir").GetComponent<Image>();
        if (deplacementsJoueur.mort)
        {
            StartCoroutine(CommencerFondu());
        }
    }

    public void FonduAuNoir()
    {
        StartCoroutine(Fondu(0f, 1f));
    }

    public void FonduInverse()
    {
        StartCoroutine(Fondu(1f, 0f));
        joueur.transform.position = respawn.transform.position;
        statsJoueur.radiation = 0;
    }

    IEnumerator CommencerFondu()
    {
        FonduAuNoir();
        yield return new WaitForSeconds(4);
        FonduInverse();
        StopCoroutine(CommencerFondu());
    }

    IEnumerator Fondu(float alphaDebut, float alphaFin)
    {
        float temps = 0f;
        Color couleur = image.color;
        while (temps < duree)
        {
            float alpha = Mathf.Lerp(alphaDebut, alphaFin, temps / duree);
            image.color = new Color(couleur.r, couleur.g, couleur.b, alpha);
            temps += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(couleur.r, couleur.g, couleur.b, alphaFin);
    }
}
