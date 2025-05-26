using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public static class GestionSauvegarde
{
    public static DataContractSerializer Serializer { get; private set; } = new DataContractSerializer(typeof(EtatJeu));
    public static string FilePath { get; private set; } = Application.persistentDataPath + "/save.sav";

    public static bool TryRead(out EtatJeu etat)
    {
        if (File.Exists(FilePath))
        {
            FileStream file = File.Open(FilePath, FileMode.Open);
            etat = (EtatJeu)Serializer.ReadObject(file);
            file.Close();
            return true;
        }
        etat = null;
        return false;
    }

    public static void Write(EtatJeu etat)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(EtatJeu));
        string filePath = Application.persistentDataPath + "/save.sav";
        FileStream file = File.Create(filePath);
        if (file != null)
        {
            serializer.WriteObject(file, etat);
            file.Close();
#if UNITY_EDITOR
            Debug.Log("Save file written at " + filePath);
#endif
        }
    }
}
