using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour
{
    public PlayerController test;
    public enum Weapons { none, sword, axe, spear }
    public Weapons curWeapon = Weapons.sword;
    public Button specialButton;

    private void Update()
    {
        specialButton.interactable = (curWeapon == Weapons.none) ? false : true;
    }

    public void special_attack()
    {
        switch(curWeapon)
        {
            case (Weapons.sword):
                test.sword_attack();
                break;
            case (Weapons.axe):
                test.axe_hit(1.5f);
                break;
            case (Weapons.spear):
                test.spear_attack();
                break;
        }
    }
}
