using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string nom;
    public int prix;
    public bool vendable;
    [TextArea]
    public string description;
}
