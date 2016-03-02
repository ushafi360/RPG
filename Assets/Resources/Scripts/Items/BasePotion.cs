using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePotion : BaseItem {

	public enum PotionTypes
    {
        HEALTH,
        MANA
    }

    private int potionPoints;
    private PotionTypes potionType;

    public BasePotion()
    {

    }

    public BasePotion(Dictionary<string, string> dict) : base(dict)
    {
        PotionType = (PotionTypes)System.Enum.Parse(typeof(PotionTypes), dict[Constant.ItemDB.Keys.POTION_TYPE].ToString());
    }

    public int PotionPoints
    {
        get { return potionPoints; }
        set { potionPoints = value; }
    }
    public PotionTypes PotionType
    {
        get { return potionType; }
        set { potionType = value; }
    }

}
