using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public bool battle = true;
    public PlayerController player;
    public bool player_turn = true;
    public GameObject battleCanvas;
    public List<EnemyController> enemies = new List<EnemyController>();
    public bool canAttack;
    public GameObject walls;

    public void BattleOver()
    {
        battle = true;
        battleCanvas.gameObject.SetActive(false);
        walls.SetActive(true);
    }

    public void RemoveEnemy(EnemyController enem)
    {
        enemies.Remove(enem);
    }

    private void Update ()
    {   
        if (!battle && enemies.Count <= 0)
        {
            BattleOver();
        }

        if (Application.isEditor && !battle && Input.GetKeyDown(KeyCode.K))
        {
            if (enemies.Count > 0)
            {
                foreach (EnemyController enem in enemies)
                {
                    enem.TakeDamage(9999);
                }
            }
        }

        if (player_turn == false)
        {
            foreach (EnemyController enem in enemies)
            {
                enem.ChooseAttack();
            }
            player_turn = true;

            //For invoking enemy turns
            /*foreach (EnemyController enem in enemies)
            {
                enem.Invoke("ChooseAttack", 0.5f);
                if (!enem.IsInvoking())
                    player_turn = true;
            }*/
        }
    }

}

