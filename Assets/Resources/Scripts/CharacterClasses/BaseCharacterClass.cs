using System;

[Serializable]
public class BaseCharacterClass {

    public string CharacterClassName { get; set; }
    public string CharacterClassDesc { get; set; }
    public int Stamina { get; set; }
    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Intellect { get ; set ; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Defense { get; set; }
    public int MagicResist { get; set; }
    public int Vitality { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }

}
