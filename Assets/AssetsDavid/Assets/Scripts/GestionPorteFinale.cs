using UnityEngine;
using UnityEngine.Animations;
using TMPro;
using UnityEngine.UI;

public class GestionPorteFinale : MonoBehaviour
{    
    static int chancesCode;
    private int code = 123;
    public bool interagis = false;
    public GameObject inputCodeObjet;
    public TMP_InputField inputCode;

    void Start()
    {
        chancesCode = 3;
        inputCodeObjet.SetActive(false);
    }
    
    void Update()
    {
        string input = inputCode.text;
        GestionCode(input);
    }

    public void InteractionConsole()
    {
        interagis = !interagis;
        Time.timeScale = interagis ? 0 : 1;

        if(interagis)
        {
            inputCodeObjet.SetActive(true);
        }
        else
        {
            inputCodeObjet.SetActive(false);
        }
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
                }
                else
                {
                    Debug.Log("Mauvais Code");
                    chancesCode--;
                }
            }
        }
    }
}
