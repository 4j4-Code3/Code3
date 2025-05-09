using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Autre")]
public class ItemData : ScriptableObject
{
    // Pour créer les données d'un item
    public string nom;
    public Sprite icone;
    [TextArea]
    public string description;
}
