using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

    private BaseWeapon newWeapon;

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();
        //Assign name to the weapon
        newWeapon.ItemName = "W"+ Random.Range(1,101);
        //Give a weapon description
        newWeapon.ItemDesc = "A new weapon";
        //Weapon ID
        newWeapon.ItemID = Random.Range(1, 101);
        //Stats
        newWeapon.Stamina = Random.Range(1, 10);
        newWeapon.Endurance = Random.Range(1, 10);
        newWeapon.Intellect = Random.Range(1, 10);
        newWeapon.Strength = Random.Range(1, 10);
        //Chose Weapon Type
        ChooseWeaponType();
        //Spell Effect ID
        newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        System.Array weapons = System.Enum.GetValues(typeof(BaseWeapon.WeaponTypes));
        newWeapon.WeaponType = (BaseWeapon.WeaponTypes)Random.Range(0,weapons.Length);
    }

	// Use this for initialization
	void Start () {
        CreateWeapon();
        Debug.Log(newWeapon.ItemName);
        Debug.Log(newWeapon.ItemID.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
