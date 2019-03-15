using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeController : EnemyController
{
    BattleController controller;
    public Image health_bar;
    public Text health;

    void Awake()
    {
        controller = GameObject.Find("BattleController").GetComponent<BattleController>();
    }

    public override void MainAttack()
    {
        controller.player.TakeDamage(atk);
    }


    public override void SpecialAttack()
    {
        Debug.Log("Special Attack");
        canSpecialAttack = false;
    }

    public override void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Slime HP: " + hp;
        if (hp <= 0)
        {
            DeadEnemy();
        }
    }
}
