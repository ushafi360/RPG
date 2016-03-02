using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseWeapon : BaseItem {    //BaseWeapon <- BaseItem

	public enum WeaponTypes
    {
        SWORD,  // Equipment for Warrior
        STAFF,  // Equipment for Mage
        DAGGER, // Equipment for Thief
        BOW,    // Equipment for Archer
        SHIELD, // Equipment for Warrior
        ARROW   // Equipment for Archer
    }

    private WeaponTypes weaponType;
    private int spellEffectID;  // TODO We might replace this with status effect

    public BaseWeapon()
    {
        ItemType = ItemTypes.WEAPON;
    }

    public BaseWeapon(Dictionary<string, string> dict) : base(dict)
    {
        WeaponType = (WeaponTypes)System.Enum.Parse(typeof(WeaponTypes), dict[Constant.ItemDB.Keys.WEAPON_TYPE].ToString());
    }

    public WeaponTypes WeaponType
    {
        get { return weaponType; }
        set { weaponType = value; }
    }
    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }

}
