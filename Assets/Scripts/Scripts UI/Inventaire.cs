using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventaire", menuName = "Inventaire")]
public class Inventaire : ScriptableObject
{
   public List<ItemData> items = new List<ItemData>();
   public int debris;
    
}
