using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string nom;
    public int prix;
    public int degats;
    [TextArea]
    public string description;
}
