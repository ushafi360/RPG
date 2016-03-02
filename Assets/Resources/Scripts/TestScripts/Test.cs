using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void OnGUI()
    {
        if(GUI.Button(new Rect(20,20,30,30),"Save Player Information"))
        {
            PlayerManager._PlayerManager.StoreCharacterInfo();
        }
        if (GUI.Button(new Rect(40, 40, 30, 30), "Load Player Information"))
        {
            PlayerManager._PlayerManager.LoadCharacterInfo();
        }
        if (GUI.Button(new Rect(60, 60, 30, 30), "Modify"))
        {
            PlayerManager._PlayerManager.Modify();
        }
        if (GUI.Button(new Rect(80, 60, 130, 130), "Show Items"))
        {
            ItemDatabase._ItemDBManager.DumpDatabase();
        }
    }
}
