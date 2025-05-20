using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestionSpawnEtage1 : MonoBehaviour
{
    public GestionRaycastsJoueur gestionRaycastsJoueur;
    public Image image;
    private float duree = 2f;

    void Start()
    {
        GameObject joueur = GameObject.Find("Numero3");
        GameObject spawn = GameObject.Find("SpawnEtage1");
        image = GameObject.Find("FonduNoir")?.GetComponent<Image>();
        gestionRaycastsJoueur = GameObject.Find("Main Camera")?.GetComponent<GestionRaycastsJoueur>();

        if (gestionRaycastsJoueur.generateur && gestionRaycastsJoueur.fonctionne)
        {
            joueur.transform.position = spawn.transform.position;
        }
        StartCoroutine(CommencerFonduInverse());
    }

    public void FonduInverse()
    {
        StartCoroutine(Fondu(1f, 0f));
    }

    IEnumerator CommencerFonduInverse()
    {
        FonduInverse();
        yield return new WaitForSeconds(4);
        StopCoroutine(CommencerFonduInverse());
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

