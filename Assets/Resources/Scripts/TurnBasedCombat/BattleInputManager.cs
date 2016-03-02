using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BattleInputManager {

    //private GameObject target;

    public enum KeyPressed
    {
        KEY_UP = 1,
        KEY_DOWN = -1,
        KEY_LEFT = -2,
        KEY_RIGHT = 2,
        KEY_NOT_PRESSED = 0,
        KEY_ACTION
    }

    public BattleInputManager()
    {
        //target = GameObject.FindGameObjectWithTag(Constant.Tags.INPUT_RECIEVER);
    }

	public KeyPressed GetPlayerInput()
    {
        if (Input.GetButtonDown("Action"))
        {
            return KeyPressed.KEY_ACTION;
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            return (KeyPressed)Mathf.CeilToInt(Input.GetAxis("Vertical") - 0.5f);
            //SendKeyPressed(key_pressed);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            return (KeyPressed)(Mathf.CeilToInt(Input.GetAxis("Horizontal") - 0.5f) * 2);
            //SendKeyPressed(key_pressed);
        }

        return KeyPressed.KEY_NOT_PRESSED;

    }

    private void SendKeyPressed(KeyPressed key_pressed)
    {
        //ExecuteEvents.Execute<Interfaces.IReceiveInput>(target, null, (x, y) => x.ReceiveInput(key_pressed));
    }

}
