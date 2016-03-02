using UnityEngine;
using System.Collections;

public class EquipmentManager {

    // Weapons
    private BaseItem leftHand;
    private BaseItem rightHand;
    // Equipment
    private BaseItem[] equipment;

    public EquipmentManager()
    {
        equipment = new BaseEquipment[Constant.NUM_OF_EQUIPMENT_SLOTS];
        InitializeEquipment();
    }

    public void EquipWeapon(BaseItem item, bool isLeftHanded)
    {
        if(item.ItemType == BaseItem.ItemTypes.WEAPON)
        {
            if (isLeftHanded)
            {
                leftHand = item;
            }
            else
            {
                rightHand = item;
            }
        }
    }

    public void Equip(BaseItem item)
    {
        if(item.ItemType == BaseItem.ItemTypes.EQUIPMENT)
        {
            for (int i = 0; i < Constant.NUM_OF_EQUIPMENT_SLOTS; i++)
            {
                if (((BaseEquipment)item).EquipmentType == ((BaseEquipment)equipment[i]).EquipmentType)
                {
                    equipment[i] = item;
                    return;
                }
            }

            Debug.Log(item.ItemName + " was not equipped. Equipment type is invalid");
        }
        Debug.Log(item.ItemName + " was not equipped. Item type is not " + BaseEquipment.ItemTypes.EQUIPMENT);

    }

    private void InitializeEquipment()
    {

        for(int i = 0; i < Constant.NUM_OF_EQUIPMENT_SLOTS; i++)
        {
            equipment[i].ItemType = BaseItem.ItemTypes.EQUIPMENT;
        }

        ((BaseEquipment)equipment[0]).EquipmentType = BaseEquipment.EquipmentTypes.CHEST_WEAR;
        ((BaseEquipment)equipment[1]).EquipmentType = BaseEquipment.EquipmentTypes.HEAD_GEAR;
        ((BaseEquipment)equipment[2]).EquipmentType = BaseEquipment.EquipmentTypes.LEG_WEAR;
        ((BaseEquipment)equipment[3]).EquipmentType = BaseEquipment.EquipmentTypes.NECK_WEAR;
        ((BaseEquipment)equipment[4]).EquipmentType = BaseEquipment.EquipmentTypes.RING;
        ((BaseEquipment)equipment[5]).EquipmentType = BaseEquipment.EquipmentTypes.SHOES;
        ((BaseEquipment)equipment[6]).EquipmentType = BaseEquipment.EquipmentTypes.SHOULDER_GUARD;
    }

}
