using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleGUI {

    private RectTransform panelPlayerInfo;
    private RectTransform panelAction;
    private bool isPanelPlayerInfoActive;   // This will be true if coroutine to show panel is started
    private bool isPanelActionActive;
    private List<BasePlayer> battleParticipants;
    private bool[] selectionActionMenu;
    private GameObject[] panelActionItems;
    private GridLayoutGroup actionGrid; 

    public enum BattleGUIStates
    {
        PLAYER_INFO,
        ACTION_SELECTION,
        LIST_SELECTION,
        ENEMY_SELECTION
    }

    public BattleGUI()
    {
        /*UnityEngine.Object panelPrefab = Resources.Load(Constant.PrefabsPaths.UI_PANEL_PLAYER_INFO);
        if (panelPrefab != null)
        {
            panelPlayerInfo = (RectTransform)((GameObject)GameObject.Instantiate(panelPrefab)).transform;
            panelPlayerInfo.SetParent(GameObject.Find("Canvas").transform, false);
            panelPlayerInfo.name = "PlayerInfo";
            panelPlayerInfo.GetComponent<CanvasGroup>().alpha = 0.0f;
        }
        isPanelPlayerInfoActive = false;

        UnityEngine.Object panelPrefab1 = Resources.Load(Constant.PrefabsPaths.UI_PANEL_ACTION);
        if (panelPrefab1 != null)
        {
            panelAction = (RectTransform)((GameObject)GameObject.Instantiate(panelPrefab1)).transform;
            panelAction.SetParent(GameObject.Find("Canvas").transform, false);
            panelAction.name = "Action";
            panelAction.GetComponent<CanvasGroup>().alpha = 0.0f;
        }
        isPanelActionActive = false;

        // Instantiating Items of panel action
        panelActionItems = new GameObject[Constant.GUI.NUMBER_OF_PANEL_ACTION_ITEMS];
        for(int i = 0; i < Constant.GUI.NUMBER_OF_PANEL_ACTION_ITEMS; i++)
        {
            panelActionItems[i] = GameObject.FindGameObjectWithTag(Constant.Tags.UI_PANEL_ACTION + i);
            if(panelActionItems[i] == null)
            {
                Debug.LogWarning("Action not loaded: " + Constant.Tags.UI_PANEL_ACTION + i);
            }
        }

        // TODO Select the first action item
        */
    }

    // Main Choices are attack, abilities, items and flee
    public void DisplayPanelPlayerInfo(ref List<BasePlayer> battleParticipant)
    {
        // Sort battleParticipant according to ascending order of their IDs
        battleParticipant.Sort((x, y) => x.ID.CompareTo(y.ID));
        battleParticipants = battleParticipant;

        // Display Player Info panel if not already visibile
        if (!isPanelPlayerInfoActive)
        {
            Fade(panelPlayerInfo, Constant.GUI.ALPHA_MIN, Constant.GUI.ALPHA_MAX, Constant.GUI.FADE_TIME);
            isPanelPlayerInfoActive = true;

            // TODO Replace string additions with a static StringBuilder helper class functions
            // Update Values of Player Info panel
            // Only call when player values change.
            UpdatePlayerInfoPanel();

            Debug.Log("Displaying Player Info panel");
        }
    }

    public void HidePanelPlayerInfo()
    {
        if (isPanelPlayerInfoActive)
        {
            Fade(panelPlayerInfo, Constant.GUI.ALPHA_MAX, Constant.GUI.ALPHA_MIN, Constant.GUI.FADE_TIME);
            isPanelPlayerInfoActive = true;
            Debug.Log("Hiding Player Info panel");
        }
    }

    public void DisplayPanelAction()
    {
        // Display Action panel if not already visibile
        if (!isPanelActionActive)
        {
            Fade(panelAction, Constant.GUI.ALPHA_MIN, Constant.GUI.ALPHA_MAX, Constant.GUI.FADE_TIME);
            isPanelActionActive = true;
            Debug.Log("Displaying Action panel");
        }
    }

    public void HidePanelAction()
    {
        if (isPanelActionActive)
        {
            Fade(panelAction, Constant.GUI.ALPHA_MAX, Constant.GUI.ALPHA_MIN, Constant.GUI.FADE_TIME);
            isPanelActionActive = false;
            Debug.Log("Hiding Action panel");
        }
    }

    // Displays the abilities of the currently selected player character 
    public void DisplayAbilityChoices()
    {

    }

    // Displays the items the currently selected player has
    public void DisplayItemChoices()
    {

    }

    public void SelectUpperChoice()
    {

    }

    public void SelectLowerChoice()
    {

    }

    public void SelectRightChoice()
    {

    }

    public void SelectLeftChoice()
    {

    }

    private void Fade(RectTransform rect, float startVal, float endVal, float time)
    {
        CoroutineManager._CoroutineManager.MakeCoroutine(CRFade(rect,startVal,endVal,time));
    }

    private IEnumerator CRFade(RectTransform rect, float startVal, float endVal, float time)
    {
        CanvasGroup tempCanvasGroup = rect.GetComponent<CanvasGroup>();
        
        tempCanvasGroup.alpha = startVal;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t = t + Time.deltaTime / time;

            startVal = tempCanvasGroup.alpha;

            tempCanvasGroup.alpha = Vector2.Lerp(new Vector2(startVal, 0), new Vector2(endVal,0), t).x;
            //Debug.Log(t);
            yield return null;
        }
        Debug.Log("Fade Coroutine Finished");
        yield break;
    }

    private void UpdatePlayerInfoPanel()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag(Constant.Tags.UI_PLAYER_CHARACTER_0);
        for (int i = 0; i < obj.Length; i++)
        {
            Text txt = obj[i].GetComponent<Text>();

            if (obj[i].name.Contains(Constant.GUI.NAME))
            {
                txt.text = battleParticipants[0].PlayerName;
            }
            else if (obj[i].name.Contains(Constant.GUI.HP))
            {
                txt.text = battleParticipants[0].statManager.CurrentHP + "/" + battleParticipants[0].statManager.MaxHP;
            }
            else if (obj[i].name.Contains(Constant.GUI.MP))
            {
                txt.text = battleParticipants[0].statManager.CurrentMP + "/" + battleParticipants[0].statManager.MaxMP;
            }
        }

        obj = GameObject.FindGameObjectsWithTag(Constant.Tags.UI_PLAYER_CHARACTER_1);
        for (int i = 0; i < obj.Length; i++)
        {
            Text txt = obj[i].GetComponent<Text>();
            Debug.Log(txt.ToString());

            if (obj[i].name.Contains(Constant.GUI.NAME))
            {
                txt.text = battleParticipants[1].PlayerName;
            }
            else if (obj[i].name.Contains(Constant.GUI.HP))
            {
                txt.text = battleParticipants[1].statManager.CurrentHP + "/" + battleParticipants[1].statManager.MaxHP;
            }
            else if (obj[i].name.Contains(Constant.GUI.MP))
            {
                txt.text = battleParticipants[1].statManager.CurrentMP + "/" + battleParticipants[1].statManager.MaxMP;
            }
        }

        obj = GameObject.FindGameObjectsWithTag(Constant.Tags.UI_PLAYER_CHARACTER_2);
        for (int i = 0; i < obj.Length; i++)
        {
            Text txt = obj[i].GetComponent<Text>();

            if (obj[i].name.Contains(Constant.GUI.NAME))
            {
                txt.text = battleParticipants[2].PlayerName;
            }
            else if (obj[i].name.Contains(Constant.GUI.HP))
            {
                txt.text = battleParticipants[2].statManager.CurrentHP + "/" + battleParticipants[2].statManager.MaxHP;
            }
            else if (obj[i].name.Contains(Constant.GUI.MP))
            {
                txt.text = battleParticipants[2].statManager.CurrentMP + "/" + battleParticipants[2].statManager.MaxMP;
            }
        }

        obj = GameObject.FindGameObjectsWithTag(Constant.Tags.UI_PLAYER_CHARACTER_3);
        for (int i = 0; i < obj.Length; i++)
        {
            Text txt = obj[i].GetComponent<Text>();

            if (obj[i].name.Contains(Constant.GUI.NAME))
            {
                txt.text = battleParticipants[3].PlayerName;
            }
            else if (obj[i].name.Contains(Constant.GUI.HP))
            {
                txt.text = battleParticipants[3].statManager.CurrentHP + "/" + battleParticipants[3].statManager.MaxHP;
            }
            else if (obj[i].name.Contains(Constant.GUI.MP))
            {
                txt.text = battleParticipants[3].statManager.CurrentMP + "/" + battleParticipants[3].statManager.MaxMP;
            }
        }
    }

    private void ResetSelectCursor()
    {

    }
}
