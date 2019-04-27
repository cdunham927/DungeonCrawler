using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public PlayerController test;

    public void special_attack()
    {
        // I still need a way to check the players weapon.
        /*
         if(player.weapon() == axe)
         {
         test.axe_hit(2f);
           }
           else if(player.weapon() == spear)
           {
           test.spear_attack();

           }


         */

        test.axe_hit(2f);
    }
}
