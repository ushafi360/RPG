using System;

[Serializable]
public class BasePlayer {

    public int ID { get; set; }
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public BaseCharacterClass PlayerClass { get; set; }
    //Stats
    public StatManager statManager;

    public BasePlayer()
    {
        if(statManager == null)
        {
            statManager = new StatManager();
        }
    }

}
