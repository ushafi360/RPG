using UnityEngine;
using System.Collections;

public class SaveInformation {

	public static void Save()
    {
        PPSerialization serializer = new PPSerialization();
        serializer.SaveToFile();
        GameInformation.DisplayGameInformation();
    }

}
