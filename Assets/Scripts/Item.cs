using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string nom;
    public int prix;
    public int degats;
    public Sprite icone;
    [TextArea]
    public string description;
}
