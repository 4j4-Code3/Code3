using UnityEditor;
using UnityEngine;

public class GestionIDItem : EditorWindow
{
    [MenuItem("Tools/Assign Unique IDs to ItemData")]
    public static void AssignIDs()
    {
        string[] guids = AssetDatabase.FindAssets("t:ItemData");

        int updatedCount = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);

            if (item != null && string.IsNullOrEmpty(item.ID))
            {
                Undo.RecordObject(item, "Assign Unique ID");
                item.ID = System.Guid.NewGuid().ToString();
                EditorUtility.SetDirty(item);
                updatedCount++;
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log($"Assigned unique IDs to {updatedCount} ItemData assets.");
    }
}
