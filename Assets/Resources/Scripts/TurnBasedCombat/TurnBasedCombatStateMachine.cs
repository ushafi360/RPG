using UnityEngine;
using System.Collections;
using System;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private BattleManager battleManager;

    public enum BattleStates
    {
        START,
        PLAYER_CHOICE,
        CALC_DAMAGE,
        ENEMY_CHOICE,
        LOSE,
        WIN
    }

    private BattleStates currentState;
    private BattleGUI.BattleGUIStates currentGUIState;
	// Use this for initialization
	void Start () {
        // TEST_CODE
        BaseItem potion = ItemDatabase._ItemDBManager.GetRandomItem();
        Inventory._Inventory.AddToInventory(potion);
        Inventory._Inventory.AddToInventory(potion);
        potion = ItemDatabase._ItemDBManager.GetRandomItem();
        Inventory._Inventory.AddToInventory(potion);
        potion = ItemDatabase._ItemDBManager.GetRandomItem();
        Inventory._Inventory.AddToInventory(potion);
        Inventory._Inventory.AddToInventory(potion);
        // TEST_CODE END
        battleManager = new BattleManager();
        currentState = BattleStates.START;
        currentGUIState = BattleGUI.BattleGUIStates.PLAYER_INFO;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentState);
        switch (currentState)
        {
            case BattleStates.START:
                battleManager.InstantiateBattle(ref currentState);
                break;
            case BattleStates.PLAYER_CHOICE:
                battleManager.GetPlayerInput(ref currentState);
                break;
            case BattleStates.ENEMY_CHOICE:
                break;
            case BattleStates.LOSE:
                break;
            case BattleStates.WIN:
                //IncreaseExperience.AddExperience();
                break;
        }
	}

    private void OnGUI()
    {
        switch (currentState)
        {
            case BattleStates.START:
                //battleManager.GUIDisplayPlayerInfo(currentGUIState);
                break;
            case BattleStates.PLAYER_CHOICE:
                //battleManager.GUIDisplayPlayerChoices(currentGUIState);
                break;
            case BattleStates.ENEMY_CHOICE:
                break;
            case BattleStates.LOSE:
                break;
            case BattleStates.WIN:
                //IncreaseExperience.AddExperience();
                break;
        }


        if (GUILayout.Button("NEXT_STATE"))
        {
            if(currentState == BattleStates.START)
            {
                currentState = BattleStates.PLAYER_CHOICE;
            }
            else if (currentState == BattleStates.PLAYER_CHOICE)
            {
                currentState = BattleStates.ENEMY_CHOICE;
            }
            else if (currentState == BattleStates.ENEMY_CHOICE)
            {
                currentState = BattleStates.LOSE;
            }
            else if (currentState == BattleStates.LOSE)
            {
                currentState = BattleStates.WIN;
            }
            else if (currentState == BattleStates.WIN)
            {
                currentState = BattleStates.START;
            }
        }
    }

    private void GUIStateMachine()
    {
        switch (currentGUIState)
        {
            case BattleGUI.BattleGUIStates.PLAYER_INFO:

                break;
            case BattleGUI.BattleGUIStates.ACTION_SELECTION:

                break;
            case BattleGUI.BattleGUIStates.LIST_SELECTION:

                break;
            case BattleGUI.BattleGUIStates.ENEMY_SELECTION:

                break;
        }
    }

}
