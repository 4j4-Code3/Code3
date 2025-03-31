using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Script à mettre sur un GameObject qu'on souhaite préserver au travers des scènes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
