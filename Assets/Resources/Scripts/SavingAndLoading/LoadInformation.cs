using UnityEngine;
using System.Collections;

public class LoadInformation {

	public static void Load()
    {
        PPSerialization serializer = new PPSerialization();
        serializer.LoadFromFile();
        GameInformation.DisplayGameInformation();
    }
}
