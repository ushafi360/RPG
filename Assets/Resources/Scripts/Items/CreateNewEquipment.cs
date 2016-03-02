using UnityEngine;
using System.Collections;

public class CreateNewEquipment : MonoBehaviour {

    private BaseEquipment newEquipment;
    private string[] itemNames = new string[4] { "Common", "Great", "Amazing", "Insane" };
    private string[] itemDesc = new string[2] { "A new cool item", "A new not so cool item"};

    private void CreateEquipment()
    {
        newEquipment = new BaseEquipment();
        newEquipment.ItemName = itemNames[Random.Range(0,3)] + " Item";
        newEquipment.ItemID = Random.Range(1, 101);
        ChooseItemType();
        newEquipment.ItemDesc = itemDesc[Random.Range(0,itemDesc.Length)];
        newEquipment.Stamina = Random.Range(1, 10);
        newEquipment.Endurance = Random.Range(1, 10);
        newEquipment.Intellect = Random.Range(1, 10);
        newEquipment.Strength = Random.Range(1, 10);
    }

    private void ChooseItemType()
    {
        System.Array equipment = System.Enum.GetValues(typeof(BaseEquipment.EquipmentTypes));
        newEquipment.EquipmentType = (BaseEquipment.EquipmentTypes)Random.Range(0, equipment.Length);
    }

	// Use this for initialization
	void Start () {
        CreateEquipment();
        Debug.Log(newEquipment.ItemName);
        Debug.Log(newEquipment.ItemID.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
