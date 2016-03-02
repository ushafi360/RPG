using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

    public static BasePlayer ChJohn { get; set; }
    public static BasePlayer ChDaisy { get; set; }
    public static BasePlayer ChHan { get; set; }
    public static BasePlayer ChHarry { get; set; }
    
    
    

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static void DisplayGameInformation()
    {
        DisplayBasePlayer(ChDaisy);
        DisplayBasePlayer(ChHan);
        DisplayBasePlayer(ChJohn);
        DisplayBasePlayer(ChHarry);
    }

    private static void DisplayBasePlayer(BasePlayer player)
    {
        Debug.Log("\n");
        Debug.Log(player.PlayerName);
        Debug.Log(player.PlayerLevel);
        Debug.Log(player.PlayerClass.CharacterClassName);
        Debug.Log(player.statManager.MaxHP);
        Debug.Log(player.statManager.MaxMP);
        Debug.Log(player.statManager.Armor);
        Debug.Log(player.statManager.MagicResist);
        Debug.Log(player.statManager.Strength);
        Debug.Log(player.statManager.Intellect);
        Debug.Log(player.statManager.Speed);
        Debug.Log(player.statManager.Vitality);
        Debug.Log(player.statManager.Endurance);
        Debug.Log(player.statManager.Luck);
        Debug.Log("\n");
    }

}
