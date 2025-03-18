using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Autre")]
public class ItemData : ScriptableObject
{
    public string nom;
    public int prix;
    public Sprite icone;
    [TextArea]
    public string description;
}
