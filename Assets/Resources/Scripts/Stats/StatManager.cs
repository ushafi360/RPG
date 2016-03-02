using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class StatManager {

    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public int Intellect { get; set; }
    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }
    public int CurrentMP { get; set; }
    public int MaxMP { get; set; }
    public int Armor { get; set; }
    public int MagicResist { get; set; }
    public int Vitality { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }
}
