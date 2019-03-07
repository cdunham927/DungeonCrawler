using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public bool battle = true;
    public EnemyController enemy;
    public PlayerController player;
    public bool player_turn = true;

    private void Update ()
    {   
        if (player_turn == false)
        {
            enemy.MainAttack();
            player_turn = true;
        }
    }
}

