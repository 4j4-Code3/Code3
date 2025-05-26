using UnityEngine;

public class Curseur : MonoBehaviour
{
    public Texture2D imageCurseurDefaut;
    public Texture2D imageCurseurActif;

    void Start()
    {
        Cursor.SetCursor(imageCurseurDefaut, Vector2.zero, CursorMode.Auto);
    }
}
