using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager {

    private BattleCalculations battleCal;
    private BattleGUI battleGUI;
    private List<BasePlayer> battleParticipants;
    private BasePlayer[] enemy;
    private int numOfEnemies;
    private int[] turns;
    private int currentTurnIndex;
    private BattleInputManager battleInput;

    private int CurrentTurnIndex
    {
        get { return currentTurnIndex; }
        set { currentTurnIndex = value % (numOfEnemies + Constant.NUM_OF_PLAYERS); }
    }


    // TODO DUMMY Function
    private void DummyGeneratePlayers()
    {
        BasePlayer ch = null;

        DummyInstantiatePlayer(ref ch, "Daisy", "WARRIOR", 0);
        GameInformation.ChDaisy = ch;
        DummyInstantiatePlayer(ref ch, "John", "ARCHER", 1);
        GameInformation.ChJohn = ch;
        DummyInstantiatePlayer(ref ch, "Han", "THIEF", 2);
        GameInformation.ChHan = ch;
        DummyInstantiatePlayer(ref ch, "Harry", "MAGE", 3);
        GameInformation.ChHarry = ch;
    }
    // TODO DUMMY Function
    private void DummyInstantiatePlayer(ref BasePlayer player, string name, string playerClass, int id)
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

        player.ID = id;
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

    public BattleManager()
    {
        battleCal = new BattleCalculations();
        battleParticipants = new List<BasePlayer>();
        battleInput = new BattleInputManager();
        battleGUI = new BattleGUI();
    }

    public void InstantiateBattle(ref TurnBasedCombatStateMachine.BattleStates currentState)
    {
        // TODO Create enemies according to Location. Have an object which returns array of
        // enemies to be choosen from
        // ChooseEnemies(enemies, ref numOfEnemies);
        numOfEnemies = 3;
        // TODO Create some character classes specifically for enemies, e.g. Bird, Mecha etc
        enemy = new BasePlayer[numOfEnemies];

        DummyInstantiatePlayer(ref enemy[0], "enemy0", "WARRIOR", 4);
        DummyInstantiatePlayer(ref enemy[1], "enemy1", "WARRIOR", 5);
        DummyInstantiatePlayer(ref enemy[2], "enemy2", "WARRIOR", 6);

        DummyGeneratePlayers();

        battleParticipants.Add(GameInformation.ChDaisy);
        battleParticipants.Add(GameInformation.ChHan);
        battleParticipants.Add(GameInformation.ChHarry);
        battleParticipants.Add(GameInformation.ChJohn);

        for (int i = 0; i < enemy.Length; i++)
        {
            battleParticipants.Add(enemy[i]);
        }

        Debug.Log("Number of Participants in battle are " + battleParticipants.Count);
        // Calculate the order of turns
        battleCal.GenerateTurnOrder(ref battleParticipants, out turns);

        ChooseNextState(out currentState);

    }

    public void GetPlayerInput(ref TurnBasedCombatStateMachine.BattleStates currentState)
    {
        BattleInputManager.KeyPressed keyPressed = battleInput.GetPlayerInput();

        if (keyPressed == BattleInputManager.KeyPressed.KEY_UP)
        {
            battleGUI.SelectUpperChoice();
        }
        else if (keyPressed == BattleInputManager.KeyPressed.KEY_DOWN)
        {
            battleGUI.SelectLowerChoice();
        }
        else if (keyPressed == BattleInputManager.KeyPressed.KEY_RIGHT)
        {
            battleGUI.SelectRightChoice();
        }
        else if (keyPressed == BattleInputManager.KeyPressed.KEY_LEFT)
        {
            battleGUI.SelectLeftChoice();
        }
        else if (keyPressed == BattleInputManager.KeyPressed.KEY_ACTION)
        {

        }
        else if (keyPressed == BattleInputManager.KeyPressed.KEY_NOT_PRESSED)
        {

        }
    }

    public void GUIDisplayPlayerChoices(BattleGUI.BattleGUIStates currentGUIState)
    {
        //battleGUI.DisplayPanelPlayerInfo(ref battleParticipants);
        battleGUI.DisplayPanelAction();
    }

    public void GUIDisplayPlayerInfo(BattleGUI.BattleGUIStates currentGUIState)
    {
        battleGUI.DisplayPanelPlayerInfo(ref battleParticipants);
        
    }

    private void ChooseNextState(out TurnBasedCombatStateMachine.BattleStates currentState)
    {
        if (turns[CurrentTurnIndex] < Constant.NUM_OF_PLAYERS)
        {
            currentState = TurnBasedCombatStateMachine.BattleStates.PLAYER_CHOICE;
        }
        else
        {
            currentState = TurnBasedCombatStateMachine.BattleStates.ENEMY_CHOICE;
        }
    }

    private BasePlayer GetBattleParticipantByID(int id)
    {
        return null;
    }

}
