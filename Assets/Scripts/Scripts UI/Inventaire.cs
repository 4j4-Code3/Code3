using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventaire", menuName = "Inventaire")]
public class Inventaire : ScriptableObject
{
   public List<Item> items = new List<Item>();
   public int debris;
    
}
