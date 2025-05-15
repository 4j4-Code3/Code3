using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogues : MonoBehaviour
{
    public GameObject boiteDialogues;
    public TextMeshProUGUI textComponent;
    public string[] lignes;
    public float vitesseTexte;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(textComponent.text == lignes[index])
            {
                ProchaineLigne();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lignes[index];
            }
        }
    }

    public void CommencerDialogue()
    {
        boiteDialogues.SetActive(true);
        index = 0;
        StartCoroutine(EcrireLigne());
    }

    IEnumerator EcrireLigne()
    {
        foreach (char c in lignes[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(vitesseTexte);
        }
    }

    void ProchaineLigne()
    {
        if(index < lignes.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(EcrireLigne());
        }
        else
        {
            boiteDialogues.SetActive(false);
        }
    }
}
