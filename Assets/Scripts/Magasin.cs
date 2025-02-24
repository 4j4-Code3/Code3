using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Magasin", menuName = "Magasin")]
public class Magasin : ScriptableObject
{
    public List<Item> items = new();
}
