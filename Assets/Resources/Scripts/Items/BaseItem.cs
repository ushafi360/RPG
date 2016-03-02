using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseItem {

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPON,
        POTION
    }

    public enum ItemRarity
    {
        WHITE,
        GREEN,
        BLUE,
        PURPLE,
        ORANGE,
        RED
    }

    private string itemName;
    private string itemDesc;
    private int itemID;
    private int stamina;
    private int endurance;
    private int strength;
    private int intellect;
    private int armor;
    private int magicResist;
    private int vitality;
    private int speed;
    private int luck;
    
    private ItemTypes itemType;
    private ItemRarity rarity;

    public BaseItem()
    {

    }

    public BaseItem(Dictionary<string,string> dict)
    {
        // TODO Use dict.TryGetValue it will help in solving issues which occur if Key is not present in dict
        itemName = dict[Constant.ItemDB.Keys.NAME];
        itemID = int.Parse(dict[Constant.ItemDB.Keys.ID]);
        itemDesc = dict[Constant.ItemDB.Keys.DESC];
        itemType = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), dict[Constant.ItemDB.Keys.TYPE].ToString());
        rarity = (ItemRarity)System.Enum.Parse(typeof(ItemRarity), dict[Constant.ItemDB.Keys.RARITY].ToString());
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string ItemDesc
    {
        get { return itemDesc; }
        set { itemDesc = value; }
    }
    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }
    public int Armor
    {
        get { return armor; }
        set { armor = value; }
    }
    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }
    public int MagicResist
    {
        get { return magicResist; }
        set { magicResist = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int Vitality
    {
        get { return vitality; }
        set { vitality = value; }
    }
    public ItemTypes ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }
    public ItemRarity Rarity
    {
        get { return rarity; }
        set { rarity = value; }
    }

}
