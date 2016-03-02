using System.Collections.Generic;
using UnityEngine;

public class BattleCalculations {

    private float[] turnCalculationRes;

    public void GenerateTurnOrder(ref List<BasePlayer> battleParticipants, out int[] turns)
    {
        turnCalculationRes = new float[battleParticipants.Count];

        turns = new int[battleParticipants.Count];

        for (int i = 0; i < battleParticipants.Count; i++)
        {
            turnCalculationRes[i] = battleParticipants[i].statManager.Speed * battleParticipants[i].statManager.Stamina *
                (battleParticipants[i].statManager.CurrentHP / battleParticipants[i].statManager.MaxHP) *
                battleParticipants[i].statManager.Luck / 100.0f;
            turns[i] = battleParticipants[i].ID;
        }

        // Characters with greater value of turnCalculationRes will take turn first
        SortDescendingOrder(ref turns, ref turnCalculationRes);
    }

    private void SortDescendingOrder(ref int[] turns, ref float[] turnCalculationRes)
    {
        for(int i = 0; i < turns.Length; i++)
        {
            for (int j = i + 1; j < turns.Length; j++)
            {
                if (turnCalculationRes[i] < turnCalculationRes[j])
                {
                    float tempCalcRes;
                    int tempTurn;

                    tempCalcRes = turnCalculationRes[i];
                    turnCalculationRes[i] = turnCalculationRes[j];
                    turnCalculationRes[j] = tempCalcRes;

                    tempTurn = turns[i];
                    turns[i] = turns[j];
                    turns[j] = tempTurn;
                }
            }
        }
        
    }

    private void SortAscendingOrder()
    {

    }

}
