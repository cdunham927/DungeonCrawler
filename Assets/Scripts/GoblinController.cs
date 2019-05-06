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
        controller.player.TakeDamage(atk);
    }
    

    public override void SpecialAttack()
    {
        Debug.Log("Special Attack");
        controller.player.TakeDamage(atk * 2);
    }

    public override void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    public void DeadEnemy()
    {
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
