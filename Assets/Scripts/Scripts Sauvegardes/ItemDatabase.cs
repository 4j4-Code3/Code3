using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Item/Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> allItems;

    public ItemData GetItemByID(string id)
    {
        return allItems.Find(item => item.ID == id);
    }
}
