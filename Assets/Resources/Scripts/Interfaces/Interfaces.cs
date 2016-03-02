using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Interfaces {

    public interface IReceiveInput : IEventSystemHandler
    {
        void ReceiveInput(BattleInputManager.KeyPressed key_pressed);
    }
	
}
