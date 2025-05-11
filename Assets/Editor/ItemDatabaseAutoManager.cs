using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public static class ItemDatabaseAutoManager
{
    static ItemDatabaseAutoManager()
    {
        EditorApplication.update += RunOnceOnEditorLoad;
    }

    private static void RunOnceOnEditorLoad()
    {
        EditorApplication.update -= RunOnceOnEditorLoad;
        RefreshDatabase();
    }

    public static void RefreshDatabase()
    {
        string[] dbGuids = AssetDatabase.FindAssets("t:ItemDatabase");
        if (dbGuids.Length == 0)
        {
            Debug.LogWarning("[ItemDatabaseAutoManager] No ItemDatabase asset found.");
            return;
        }

        string dbPath = AssetDatabase.GUIDToAssetPath(dbGuids[0]);
        ItemDatabase db = AssetDatabase.LoadAssetAtPath<ItemDatabase>(dbPath);
        if (db == null)
        {
            Debug.LogWarning("[ItemDatabaseAutoManager] Could not load ItemDatabase.");
            return;
        }

        string[] itemGuids = AssetDatabase.FindAssets("t:ItemData");
        List<ItemData> items = new List<ItemData>();
        int assignedCount = 0;

        foreach (string guid in itemGuids)
        {
            string itemPath = AssetDatabase.GUIDToAssetPath(guid);
            ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(itemPath);

            if (item != null)
            {
                if (string.IsNullOrEmpty(item.ID))
                {
                    Undo.RecordObject(item, "Assign Unique ID");
                    item.ID = System.Guid.NewGuid().ToString();
                    EditorUtility.SetDirty(item);
                    assignedCount++;
                }

                items.Add(item);
            }
        }

        Undo.RecordObject(db, "Auto-Update ItemDatabase");
        db.allItems = items;
        EditorUtility.SetDirty(db);
        AssetDatabase.SaveAssets();

        Debug.Log($"[ItemDatabaseAutoManager] Assigned {assignedCount} IDs and updated ItemDatabase with {items.Count} items.");
    }
}

public class ItemDataPostprocessor : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFrom)
    {
        if (AssetChangesContainItemData(imported) || AssetChangesContainItemData(deleted) || AssetChangesContainItemData(moved))
        {
            ItemDatabaseAutoManager.RefreshDatabase();
        }
    }

    private static bool AssetChangesContainItemData(string[] paths)
    {
        foreach (string path in paths)
        {
            if (path.EndsWith(".asset") && AssetDatabase.LoadAssetAtPath<ItemData>(path) != null)
                return true;
        }
        return false;
    }
}

