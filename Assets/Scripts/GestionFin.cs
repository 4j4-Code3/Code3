using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GestionFin : MonoBehaviour
{
    static int chancesCode;
    private int code = 749;
    private bool activerMauvaiseFin = false;
    public TMP_InputField inputCode;
    public TextMeshProUGUI chancesTexte;

    void Start()
    {
        chancesCode = 3;
    }

    void Update()
    {
        string input = inputCode.text;
        GestionCode(input);
        chancesTexte.text = chancesCode.ToString();
    }

    void GestionCode(string input)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (int.TryParse(input, out int codeEntre))
            {
                if (codeEntre == code)
                {
                    Debug.Log("Bon Code");
                    SceneManager.LoadScene("Victoire");
                }
                else
                {
                    Debug.Log("Mauvais Code");
                    chancesCode--;
                }
            }
        }

        if(chancesCode <= 0 && !activerMauvaiseFin)
        {
            SceneManager.LoadScene("Défaite");
        }
    }


}
