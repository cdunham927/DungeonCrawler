using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool battle = true;
    public PlayerController player;
    public bool player_turn = true;
    public Canvas BattleCanvas;
    public List<EnemyController> enemies = new List<EnemyController>();
    public bool canAttack;

    public void BattleOver()
    {
        battle = true;
        BattleCanvas.enabled = false;
    }

    public void RemoveEnemy(EnemyController enem)
    {
        enemies.Remove(enem);
    }

    private void Update ()
    {   
        if (battle == false && enemies.Count == 0)
        {
            Invoke("BattleOver", 1f);
        }

        if (player_turn == false)
        {
            foreach (EnemyController enem in enemies)
            {
                enem.ChooseAttack();
            }
            player_turn = true;
        }
    }

}

