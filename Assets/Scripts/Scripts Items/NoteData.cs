using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NoteData", menuName = "Item/Note")]
public class NoteData : ItemData
{
    // Image associée à une note
    public GameObject note;
}
