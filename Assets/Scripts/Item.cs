using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventaire/Item")]
public class Item : ScriptableObject
{
    public string nomItem;
    public int prixItem;
    public bool vendable;
}
