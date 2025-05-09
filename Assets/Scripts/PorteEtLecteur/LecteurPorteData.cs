using UnityEngine;

[CreateAssetMenu(fileName = "LecteurPorteData", menuName = "LecteurPorte")]
public class LecteurPorteData : ScriptableObject
{
    // Crée les données d'une porte
    public bool active;
    public string code;
}
