using UnityEngine;
using System;

[Serializable]
public class BaseMageClass : BaseCharacterClass {

    public BaseMageClass()
    {
        CharacterClassName = "Mage";
        CharacterClassDesc = "An intelligent scholar of magic.";
        HP = 60;
        MP = 100;
        Strength = 6;
        Intellect = 16;
        Stamina = 12;
        Defense = 10;
        MagicResist = 18;
        Vitality = 10;
        Speed = 12;
        Endurance = 13;
        Luck = 10;
    }

}
