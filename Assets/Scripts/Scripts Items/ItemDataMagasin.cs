using System;
using UnityEngine;

public enum ItemType { Radiation, SeringueEfficacite, SeringueMax, Degats }

[CreateAssetMenu(fileName = "ItemDataMagasin", menuName = "ItemDataMagasin")]
public class ItemDataMagasin : ItemData
{
    public int prix;
    public int bonus;
    public ItemType type;
}
