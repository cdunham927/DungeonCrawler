﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemController : EnemyController
{
    BattleController controller;
    PlayerController pCon;

    void Awake()
    {
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
        pCon = FindObjectOfType<PlayerController>();

        GetComponent<SpriteRenderer>().flipX = (Random.value >= 0.5f) ? true : false;

        health_bar = GetComponentInChildren<Image>();
        health = health_bar.GetComponentInChildren<Text>();
    }

    public override void MainAttack()
    {
        controller.UpdateLog("The Golem attacks! You take " + (atk).ToString() + "damage.\n");
        controller.player.TakeDamage(atk);
    }
    

    public override void SpecialAttack()
    {
        controller.UpdateLog("The Golem defends itself! Gets increased defense.\n");
        def += 3;
        canSpecialAttack = false;
    }

    public override void TakeDamage(float dmg)
    {
        controller.UpdateLog("Golem took " + dmg + " damage.\n");
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        controller.UpdateLog("You got " + xp + " from the Golem.\n");
        controller.RemoveEnemy(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Golem HP: " + hp;
        if (hp <= 0)
        {
            DeadEnemy();
        }
    }
}
