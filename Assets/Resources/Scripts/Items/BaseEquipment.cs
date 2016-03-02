using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseEquipment : BaseItem {

	public enum EquipmentTypes
    {
        HEAD_GEAR,
        CHEST_WEAR,
        SHOULDER_GUARD,
        LEG_WEAR,
        SHOES,
        NECK_WEAR,
        RING
    }

    private EquipmentTypes equipmentType;
    private int spellEffectID; // TODO Might replace it with status effects

    // Constructor
    public BaseEquipment()
    {
        ItemType = ItemTypes.EQUIPMENT;
    }

    public BaseEquipment(Dictionary<string, string> dict)
    {
        EquipmentType = (EquipmentTypes)System.Enum.Parse(typeof(EquipmentTypes), dict[Constant.ItemDB.Keys.EQUIPMENT_TYPE].ToString());
    }

    public EquipmentTypes EquipmentType
    {
        get { return equipmentType; }
        set { equipmentType = value; }
    }
    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }

    

}
