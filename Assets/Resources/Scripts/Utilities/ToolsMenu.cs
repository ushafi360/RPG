using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuItems
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/Delete Save File")]
    private static void DeleteSaveFile()
    {
        File.Delete(Application.persistentDataPath + "/playerInfo.dat");
    }
}