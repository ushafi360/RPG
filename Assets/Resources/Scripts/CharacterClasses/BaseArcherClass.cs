using UnityEngine;
using System;

[Serializable]
public class BaseArcherClass : BaseCharacterClass {

	public BaseArcherClass()
    {
        CharacterClassName = "Archer";
        CharacterClassDesc = "A keen eyed warrior.";
        HP = 80;
        MP = 60;
        Strength = 14;
        Intellect = 12;
        Stamina = 16;
        Defense = 12;
        MagicResist = 12;
        Vitality = 15;
        Speed = 20;
        Endurance = 13;
        Luck = 10;
    }
}
