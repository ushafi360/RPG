
public static class Constant {

    public const int NUM_OF_PLAYERS = 4;
    public const int NUM_OF_EQUIPMENT_SLOTS = 7;

    // Item Database Constants
    public static class ItemDB
    {
        public static class Keys
        {
            public const string ROOT = "Item";
            public const string NAME = "itemName";          // Name of the item
            public const string DESC = "itemDesc";          // Description of the item
            public const string ID = "itemID";              // ID of the item
            public const string TYPE = "itemType";          // Type of the item. Weapon, Potion etc
            public const string RARITY = "itemRarity";      // Rarity of the item. WGBPOR
            public const string WEAPON_TYPE = "weaponType"; // Type of weapon
            public const string EQUIPMENT_TYPE = "equipmentType";
            public const string POTION_TYPE = "potionType";
        }
        
    }
	
    public static class InputKeys
    {
        public const int UP = 1;
        public const int DOWN = -1;
        public const int RIGHT = 2;
        public const int LEFT = -2;
        public const int NO_INPUT = 0;
    }

    public static class Tags
    {
        public const string INPUT_RECIEVER = "InputReciever";
        public const string UI_PLAYER_CHARACTER_0 = "UIPlayerCharacter0";
        public const string UI_PLAYER_CHARACTER_1 = "UIPlayerCharacter1";
        public const string UI_PLAYER_CHARACTER_2 = "UIPlayerCharacter2";
        public const string UI_PLAYER_CHARACTER_3 = "UIPlayerCharacter3";
        public const string UI_PANEL_PLAYER_INFO = "UIPanelPlayerInfo";
        public const string UI_PANEL_ACTION = "UIPanelAction";
        public const string UI_PANEL_LIST = "UIPanelList";
        public const string UI_PANEL_ACTION_PLAYER_NAME = "UIPanelActionPlayerName";
        public const string UI_PANEL_ACTION_ATTACK = "UIPanelAction0";
        public const string UI_PANEL_ACTION_ABILITIES = "UIPanelAction1";
        public const string UI_PANEL_ACTION_ITEMS = "UIPanelAction2";
        public const string UI_PANEL_ACTION_FLEE = "UIPanelAction3";
        public const string UI_PANEL_LIST_NAME = "UIPanelListName";
        public const string UI_PANEL_LIST_ITEM = "UIPanelListItem";
        public const string UI_PANEL_LIST_ITEM_0 = "UIPanelListItem0";
        public const string UI_PANEL_LIST_ITEM_1 = "UIPanelListItem1";
        public const string UI_PANEL_LIST_ITEM_2 = "UIPanelListItem2";
        public const string UI_PANEL_LIST_ITEM_3 = "UIPanelListItem3";
        public const string UI_PANEL_LIST_ITEM_4 = "UIPanelListItem4";
        public const string UI_PANEL_LIST_ITEM_5 = "UIPanelListItem5";
        public const string UI_PANEL_LIST_ITEM_6 = "UIPanelListItem6";
        public const string UI_PANEL_LIST_ITEM_7 = "UIPanelListItem7";
        public const string UI_PANEL_LIST_ITEM_8 = "UIPanelListItem8";
        public const string UI_PANEL_LIST_ITEM_9 = "UIPanelListItem9";
        public const string UI_PANEL_LIST_ITEM_10 = "UIPanelListItem10";
        public const string UI_PANEL_LIST_ITEM_11 = "UIPanelListItem11";
    }

    public static class Paths
    {
        public const string UI_PANEL_PLAYER_INFO = "Prefabs/UI/UIPanelPlayerInfo";
        public const string UI_PANEL_ACTION = "Prefabs/UI/UIPanelAction";
        public const string XML_ITEM_DB = "XMLs/ItemDatabase";
    }

    public static class GUI
    {
        public const float ALPHA_MIN = 0.0f;
        public const float ALPHA_MAX = 1.0f;
        public const float FADE_TIME = 5.0f;
        public const string HP = "HP";
        public const string MP = "MP";
        public const string NAME = "Name";
        public const int NUMBER_OF_PANEL_ACTION_ITEMS = 4;
    }

}
