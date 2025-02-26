using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ListeItems")]
public class ListeItems : ScriptableObject
{
   public List<Item> itemsAVendre = new List<Item>();

}
