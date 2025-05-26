using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChargerScene : MonoBehaviour, IPointerClickHandler
{
    public string niveauACharger;
    public string filePath = "C:\\Users\\e2054724\\AppData\\LocalLow\\DefaultCompany\\Code3\\save.sav";

    void ChargerNiveau()
    {
        SceneManager.LoadScene(niveauACharger);
    }

    void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"File at {path} has been deleted.");
        }
        else
        {
            Debug.LogWarning($"File at {path} does not exist.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChargerNiveau();
        DeleteFile(filePath);
    }
}
