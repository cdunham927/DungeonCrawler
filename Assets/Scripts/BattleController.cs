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

    public GameObject pauseUI;
    public bool paused = false;

    public Text battleLog;
    float timeToDeleteText;
    public float lerpSpd;

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

    public void UpdateLog(string text)
    {
        battleLog.text += text + "\n";
        battleLog.color = Color.white;
        timeToDeleteText = 5f;
    }

    private void Update ()
    {
        battleLog.color = Color.Lerp(battleLog.color, new Color(1, 1, 1, 0), Time.deltaTime * lerpSpd);

        if (timeToDeleteText > 0) timeToDeleteText -= Time.deltaTime;
        else
        {
            battleLog.text = "";
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            UpdateLog("This is a line of text");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            pauseUI.SetActive(!pauseUI.activeInHierarchy);
        }

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

