using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager _PlayerManager;

    private BasePlayer chDaisy; // Warrior
    private BasePlayer chJohn;  // Archer
    private BasePlayer chHan;   // Thief
    private BasePlayer chHarry; // Mage

    private PlayerController playerCont;

    void Awake()
    {
        if(_PlayerManager == null)
        {
            DontDestroyOnLoad(this);
            _PlayerManager = this;
        }
        else if(_PlayerManager != this)
        {
            Destroy(this);
        }
    }

	// Use this for initialization
	void Start () {       
        InstantiatePlayer(ref chDaisy, "Daisy", "WARRIOR");
        InstantiatePlayer(ref chJohn, "John", "ARCHER");
        InstantiatePlayer(ref chHan, "Han", "THIEF");
        InstantiatePlayer(ref chHarry, "Harry", "MAGE");

        playerCont = gameObject.AddComponent<PlayerController>();

        // TODO Should be called when user select Load from menu
        LoadCharacterInfo();

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void InstantiatePlayer(ref BasePlayer player, string name, string playerClass)
    {
        player = new BasePlayer();
        player.PlayerLevel = 1;
        player.PlayerName = name;
        switch (playerClass)
        {
            case "WARRIOR":
                player.PlayerClass = new BaseWarriorClass();
                break;
            case "MAGE":
                player.PlayerClass = new BaseMageClass();
                break;
            case "THIEF":
                player.PlayerClass = new BaseThiefClass();
                break;
            case "ARCHER":
                player.PlayerClass = new BaseArcherClass();
                break;
        }

        player.statManager.MaxHP = player.PlayerClass.HP;
        player.statManager.MaxMP = player.PlayerClass.MP;
        player.statManager.Strength = player.PlayerClass.Strength;
        player.statManager.Intellect = player.PlayerClass.Intellect;
        player.statManager.Stamina = player.PlayerClass.Stamina;
        player.statManager.Armor = player.PlayerClass.Defense;
        player.statManager.MagicResist = player.PlayerClass.MagicResist;
        player.statManager.Vitality = player.PlayerClass.Vitality;
        player.statManager.Speed = player.PlayerClass.Speed;
        player.statManager.Endurance = player.PlayerClass.Endurance;
        player.statManager.Luck = player.PlayerClass.Luck;

        Debug.Log(playerClass + " " + name + " created successfully");
    }

    // This function will be called to store player state to disk
    public void StoreCharacterInfo()
    {
        GameInformation.ChDaisy = chDaisy;
        GameInformation.ChHan = chHan;
        GameInformation.ChHarry = chHarry;
        GameInformation.ChJohn = chJohn;
        Debug.Log("Character Information saved in GameInformation successfully");
        SaveInformation.Save();
    }

    // This function will be called to load player state from disk
    public void LoadCharacterInfo()
    {
        LoadInformation.Load();
        chDaisy = GameInformation.ChDaisy;
        chHan = GameInformation.ChHan;
        chHarry = GameInformation.ChHarry;
        chJohn = GameInformation.ChJohn;
        Debug.Log("Character Information loaded from GameInformation successfully");
    }

    public void Modify()
    {
        chDaisy.PlayerName = "Badass";
    }

}
