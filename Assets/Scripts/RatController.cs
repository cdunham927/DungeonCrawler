using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatController : EnemyController
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
        controller.UpdateLog("The Rat attacks! You take " + (atk).ToString() + "damage.\n");
        controller.player.TakeDamage(atk);
    }


    public override void SpecialAttack()
    {
        controller.UpdateLog("The Rat musters a weak defense!\n");
        def += 1;
    }

    public override void TakeDamage(float dmg)
    {
        controller.UpdateLog("Rat took " + dmg + " damage.\n");
        hp -= dmg;
    }

    public void DeadEnemy()
    {
        controller.UpdateLog("You got " + xp + " from the Rat.\n");
        controller.RemoveEnemy(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //Health
        health_bar.fillAmount = hp / maxHP;
        health.text = "Rat HP: " + hp;
        if (hp <= 0)
        {
            DeadEnemy();
            pCon.xp += xp;
        }
    }
}
