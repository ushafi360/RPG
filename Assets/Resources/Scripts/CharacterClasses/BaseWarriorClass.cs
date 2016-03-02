using UnityEngine;
using System;

[Serializable]
public class BaseWarriorClass : BaseCharacterClass {

	public BaseWarriorClass()
    {
        CharacterClassName = "Warrior";
        CharacterClassDesc = "A brave and strong fighter.";
        HP = 100;
        MP = 30;
        Strength = 20;
        Intellect = 9;
        Stamina = 16;
        Defense = 14;
        MagicResist = 10;
        Vitality = 14;
        Speed = 15;
        Endurance = 13;
        Luck = 12;
    }

}
