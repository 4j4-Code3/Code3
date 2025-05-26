using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionSpawnEtage2 : MonoBehaviour
{
    public Image image;
    private float duree = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject joueur = GameObject.Find("Numero3");
        GameObject spawn = GameObject.Find("SpawnEtage2");
        image = GameObject.Find("FonduNoir")?.GetComponent<Image>();
        
        joueur.transform.position = spawn.transform.position;
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
