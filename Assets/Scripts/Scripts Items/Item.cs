using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Autre")]
public class Item : ScriptableObject
{
    public string nom;
    public int prix;
    public Sprite icone;
    [TextArea]
    public string description;
}
