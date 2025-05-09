using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventaire", menuName = "Inventaire")]
public class Inventaire : ScriptableObject
{
   // Crée un inventaire
   public List<ItemData> items = new List<ItemData>();
   public Dictionary<NoteData, GameObject> noteMap = new();
   public int debris;
   public int seringue;
   public int maxSeringue = 5;

   public bool seringueSpeciale = false;

   public void AjouterNote(NoteData noteData, GameObject noteObject)
    {
        noteMap[noteData] = noteObject;
    }
    
}
