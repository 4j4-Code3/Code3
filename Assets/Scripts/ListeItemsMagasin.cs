using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemMagasin", menuName = "ListeItems")]
public class ListeItemsMagasin : ScriptableObject
{
   public List<Item> itemsAVendre = new List<Item>();

}
