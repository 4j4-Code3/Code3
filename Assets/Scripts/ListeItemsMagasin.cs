using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemMagasin", menuName = "ListeItems")]
public class ListeItemsMagasin : ScriptableObject
{
   public List<ItemData> itemsAVendre = new List<ItemData>();

}
