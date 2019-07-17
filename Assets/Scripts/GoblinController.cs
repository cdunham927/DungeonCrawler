using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinController : EnemyController
{   
    BattleController controller;
    PlayerController pCon;

    void Awake() 
    {
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
        pCon = FindObjectOfType<PlayerController>();
        
        health_bar = GetComponentInChildren<Image>();
        health = health_bar.GetComponentInChildren<Text>();
    }

    public override void MainAttack()
    {
        controller.UpdateLog("The Goblin attacks! You take " + (atk).ToString() + "damage.\n");
        controller.player.TakeDamage(atk);
    }
    

    public override void SpecialAttack()
    {
        controller.UpdateLog("The Goblin used its special attack! You take " + (atk * 2).ToString() + "damage.\n");
        controller.player.TakeDamage(atk * 2);
    }

    public override void TakeDamage(float dmg)
    {
        controller.UpdateLog("Goblin took " + dmg + " damage.\n");
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        controller.UpdateLog("You got " + xp + " from the Goblin.\n");
        controller.RemoveEnemy(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Goblin HP: " + hp;
        if (hp <= 0)
        {
            DeadEnemy();
            pCon.xp += xp;
        }
    }
}
