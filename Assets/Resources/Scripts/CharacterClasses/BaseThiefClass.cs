using UnityEngine;
using System;

[Serializable]
public class BaseThiefClass : BaseCharacterClass {

    public BaseThiefClass()
    {
        CharacterClassName = "Thief";
        CharacterClassDesc = "A sneaky thief.";
        HP = 70;
        MP = 50;
        Strength = 12;
        Intellect = 14;
        Stamina = 20;
        Defense = 12;
        MagicResist = 12;
        Vitality = 14;
        Speed = 18;
        Endurance = 13;
        Luck = 14;
    }
}
