using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool battle = true;
    public EnemyController enemy;
    public PlayerController player;
    public bool player_turn = true;
    public Canvas BattleCanvas;

    public void BattleOver()
    {
        battle = true;
        BattleCanvas.enabled = false;
    }
    private void Update ()
    {   
        if (battle == false && enemy == null)
        {
            Invoke("BattleOver", 1f);
        }
        if (player_turn == false)
        {
            enemy.MainAttack();
            player_turn = true;
        }
    }

}

