using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class PopulerDatabase : EditorWindow
{
    private ItemDatabase targetDatabase;

    [MenuItem("Tools/Populate ItemDatabase")]
    public static void ShowWindow()
    {
        GetWindow<PopulerDatabase>("Populate ItemDatabase");
    }

    void OnGUI()
    {
        GUILayout.Label("Auto-Populate Item Database", EditorStyles.boldLabel);

        targetDatabase = (ItemDatabase)EditorGUILayout.ObjectField("Target Database", targetDatabase, typeof(ItemDatabase), false);

        if (GUILayout.Button("Populate with All ItemData Assets"))
        {
            if (targetDatabase == null)
            {
                EditorUtility.DisplayDialog("Error", "Please assign a target ItemDatabase.", "OK");
                return;
            }

            string[] guids = AssetDatabase.FindAssets("t:ItemData");
            List<ItemData> items = new List<ItemData>();

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);
                if (item != null)
                {
                    items.Add(item);
                }
            }

            Undo.RecordObject(targetDatabase, "Populate ItemDatabase");
            targetDatabase.allItems = items;
            EditorUtility.SetDirty(targetDatabase);
            AssetDatabase.SaveAssets();

            EditorUtility.DisplayDialog("Success", $"Populated with {items.Count} items.", "OK");
        }
    }
}

