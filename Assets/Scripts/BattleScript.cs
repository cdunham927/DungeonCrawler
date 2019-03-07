using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScript : PlayerController
{
    public Button attackButton;

    void Start()
    {
        Button btn = attackButton.GetComponent<Button>();
        btn.onClick.AddListener(AttackOnClick);
    }
    void AttackOnClick()
    {
        //Output this to console when Button is clicked
        Debug.Log("You have dealt damage!");
    }
}
