using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemMagasin", menuName = "ListeItems")]
public class ListeItemsMagasin : ScriptableObject
{
   // Crée l'inventaire du magasin
   public List<ItemData> itemsAVendre = new List<ItemData>();

}
